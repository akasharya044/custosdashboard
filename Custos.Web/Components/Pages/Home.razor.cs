using System.Text;
using custos.Web.Components.Dto;
using custos.Web.Services;
using Newtonsoft.Json;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using custos.Models;
using custos.Models.SystemInfo;




namespace custos.Web.Components.Pages
{
    public partial class Home
    {

        Variant variant = Variant.Filled;
        bool loading { get; set; } = true;
        private DeviceDto device { get; set; } = new DeviceDto();
        private System.Threading.Timer? timer;
        IEnumerable<RegisterDeviceDto> _device { get; set; } = new List<RegisterDeviceDto>();
        List<DeviceDetailsDtos> _device1 { get; set; } = new List<DeviceDetailsDtos>();

        List<RegisterDeviceDto> Alldevices { get; set; } = new List<RegisterDeviceDto>();
        List<RegisterDeviceDto> rundevices { get; set; } = new List<RegisterDeviceDto>();

        //List<DeviceDetailsDtos> offlinedevices { get; set; } = new List<DeviceDetailsDtos>();
        List<RegisterDeviceDto> offdevices { get; set; } = new List<RegisterDeviceDto>();
        RadzenDataGrid<RegisterDeviceDto> _refOff;
        RadzenDataGrid<RegisterDeviceDto> _refonn;

        List<DeviceStatusPool> devicedata { get; set; } = new List<DeviceStatusPool>();


        List<DeviceStatusPool> runningdevicedata { get; set; } = new List<DeviceStatusPool>();
        List<DeviceStatusPool> offlinedevicedata { get; set; } = new List<DeviceStatusPool>();

        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };
        private static int Count { get; set; }




        protected override async Task OnInitializedAsync()
        {
            if (sessionData.UserData == null || sessionData.UserData.UserName == null)
                NavigationManager.NavigateTo("/");

            await base.OnInitializedAsync();
            loading = false;
            //await rabbitbus.ReceiveAsync<string>("dashboarddata", x=> OnMessageReceived(x));
            timer = new System.Threading.Timer(async (object? stateInfo) =>
            {
                device = SessionState.Device;
                //StateHasChanged();
                await InvokeAsync(StateHasChanged);

            }, new System.Threading.AutoResetEvent(false), 1000, 1000); // fire every 2000 milliseconds
            await LoadData();
          
            await DeviceStatusData();



        }
        private async Task UpdateDevicedto(DeviceDto input)
        {
            device = new DeviceDto() { RunningDevices = input.RunningDevices, TotalDevices = input.TotalDevices };
            //await Task.Delay(500);
            await InvokeAsync(StateHasChanged);
        }

        

        private async Task LoadData()
        {
            try
            {
                var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetRegisterDevice");
                if (output != null && output.Status == "Success")
                {
                    _device = JsonConvert.DeserializeObject<IEnumerable<RegisterDeviceDto>>(output.Data.ToString());
                    Count = _device.Count();

                    Alldevices = _device.ToList();
                    

                }
            }
            catch (Exception ex)
            {
            }
            StateHasChanged();
        }


        private async Task DeviceStatusData()
        {
            try
            {
                var output = await custosapiservice.GetData("/api/devicedetails/getdevicestatus");
                if (output != null && output.Status == "Success")
                {
                    devicedata = JsonConvert.DeserializeObject<List<DeviceStatusPool>>(output.Data.ToString());
                    runningdevicedata = devicedata.FindAll(x => x.IsRunning == true).ToList();
                    offlinedevicedata = devicedata.FindAll(x => x.IsRunning == false).ToList();
                    //runningdevices = runningdevices.Where(x => runningdevicedata!.Select(y=>y.DeviceId).Equals(x.properties.DisplayLabel)).ToList();

                    foreach (var dev in Alldevices)
                    {
                        foreach (var rundev in runningdevicedata)
                        {
                            if (rundev.DeviceId.ToLower().Equals(dev.DisplayLabel!.ToLower()))
                            {
                                dev.Status = "Running";
                                rundevices.Add(dev);
                            }
                        }
                    }

                    foreach (var dev in Alldevices)
                    {
                        foreach (var rundev in offlinedevicedata)
                        {
                            if (rundev.DeviceId.ToLower().Equals(dev.DisplayLabel!.ToLower()))
                            {
								dev.Status = "Offline";
								offdevices.Add(dev);
                            }
                        }
                    }

                }
                _refOff.Reset();
                _refonn.Reset();
                StateHasChanged();
            }

            catch (Exception ex)
            {
            }
        }

        //private async Task DownloadCsvInstalled()
        //{
        //    try
        //    {
        //        List<DeviceDetailsDtoss> datas = new List<DeviceDetailsDtoss>();
        //        _device.ToList().ForEach(x =>
        //        {
        //            DeviceDetailsDtoss data = new DeviceDetailsDtoss();
        //            data.Id = x.properties.Id;
        //            data.IsDeleted = x.properties.IsDeleted;
        //            data.entity_type = x.entity_type;
        //            data.SubType = x.properties.SubType;
        //            //data.LastUpdateTime = x.properties.LastUpdateTime;
        //            data.DisplayLabel = x.properties?.DisplayLabel;
        //            data.MfDeviceId = x.properties.MfDeviceId;
        //            data.IpAddress = x.properties.IpAddress;
        //            data.MacAddress = x.properties.MacAddress;
        //            data.AgentVersion = x.properties.AgentVersion;
        //            data.Location = x.properties.Location;
        //            data.Status = x.properties.Status;


        //            // Convert long to DateTime
        //            if (x.properties.LastUpdateTime.ToString().Length <= 10)
        //            {
        //                DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeSeconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

        //                data.LastUpdateTime = resolvedDateTime.DateTime;
        //            }
        //            else
        //            {
        //                DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

        //                data.LastUpdateTime = resolvedDateTime.DateTime;
        //            }
        //            // Format DateTime as string
        //            //string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");

        //            // Now 'formattedDate' contains the desired string representation of the resolved date

        //            datas.Add(data);



        //        });

        //        // Generate CSV content based on ticketData
        //        var csvContent = GenerateCsvContentinstalled(datas);

        //        // Prepare the file content for download
        //        var data = Encoding.UTF8.GetBytes(csvContent);

        //        // Initiate the file download using FileSaver
        //        await JSRuntime.InvokeVoidAsync("saveAsFile", "InstalledAgent.csv", data, "text/csv");
        //        //ticketData = ticketData1;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        private string GenerateCsvContentinstalled(IEnumerable<DeviceDetailsDtoss> data)
        {
            // Generate CSV content based on your data structure
            StringBuilder csvContent = new StringBuilder();

            // Add header row
            var headers = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.Name);
            csvContent.AppendLine(string.Join(",", headers));

            // Add data rows
            foreach (var item in data)
            {
                var values = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }

        //private async Task DownloadCsvUnInstalled()
        //{

        //	List<DeviceDetailsDtoss> datas = new List<DeviceDetailsDtoss>();
        //	_device1.ToList().ForEach(x =>
        //	{
        //		DeviceDetailsDtoss data = new DeviceDetailsDtoss();
        //		data.Id = x.properties.Id;
        //		data.IsDeleted = x.properties.IsDeleted;
        //		data.entity_type = x.entity_type;
        //		data.SubType = x.properties.SubType;
        //		//data.LastUpdateTime = x.properties.LastUpdateTime;
        //		data.DisplayLabel = x.properties?.DisplayLabel;
        //		data.MfDeviceId = x.properties.MfDeviceId;
        //		data.IpAddress = x.properties.IpAddress;
        //		data.MacAddress = x.properties.MacAddress;
        //		data.AgentVersion = x.properties.AgentVersion;
        //		data.Location = x.properties.Location;
        //		data.Status = x.properties.Status;


        //		// Convert long to DateTime
        //		DateTime resolvedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(x.properties.LastUpdateTime).DateTime;

        //		data.LastUpdateTime = resolvedDateTime;
        //		// Format DateTime as string
        //		//string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");

        //		// Now 'formattedDate' contains the desired string representation of the resolved date

        //		datas.Add(data);



        //	});
        //	// Generate CSV content based on ticketData
        //	var csvContent = GenerateCsvContentuninstalled(datas);

        //	// Prepare the file content for download
        //	var data = Encoding.UTF8.GetBytes(csvContent);

        //	// Initiate the file download using FileSaver
        //	await JSRuntime.InvokeVoidAsync("saveAsFile", "UnInstalledAgent.csv", data, "text/csv");
        //	//ticketData = ticketData1;
        //}


        //private string GenerateCsvContentuninstalled(IEnumerable<DeviceDetailsDtoss> data)
        //{
        //	// Generate CSV content based on your data structure
        //	StringBuilder csvContent = new StringBuilder();

        //	// Add header row
        //	var headers = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.Name);
        //	csvContent.AppendLine(string.Join(",", headers));

        //	// Add data rows
        //	foreach (var item in data)
        //	{
        //		var values = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
        //		csvContent.AppendLine(string.Join(",", values));
        //	}

        //	return csvContent.ToString();
        //}


    //    private async Task DownloadCsvOnline()
    //    {

    //        List<DeviceDetailsDtoss> datas = new List<DeviceDetailsDtoss>();
    //        rundevices.ToList().ForEach(x =>
    //        {
    //            DeviceDetailsDtoss data = new DeviceDetailsDtoss();
    //            data.Id = x.properties.Id;
    //            data.IsDeleted = x.properties.IsDeleted;
    //            data.entity_type = x.entity_type;
    //            data.SubType = x.properties.SubType;
    //            //data.LastUpdateTime = x.properties.LastUpdateTime;
    //            data.DisplayLabel = x.properties?.DisplayLabel;
    //            data.MfDeviceId = x.properties.MfDeviceId;
    //            data.IpAddress = x.properties.IpAddress;
    //            data.MacAddress = x.properties.MacAddress;
    //            data.AgentVersion = x.properties.AgentVersion;
    //            data.Location = x.properties.Location;
    //            data.Status = x.properties.Status;


				//// Convert long to DateTime
				//if (x.properties.LastUpdateTime.ToString().Length <= 10)
				//{
				//	DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeSeconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

				//	data.LastUpdateTime = resolvedDateTime.DateTime;
				//}
				//else
				//{
				//	DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

				//	data.LastUpdateTime = resolvedDateTime.DateTime;
				//}// Format DateTime as string
				// //string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");

				//// Now 'formattedDate' contains the desired string representation of the resolved date

				//datas.Add(data);



    //        });
    //        // Generate CSV content based on ticketData
    //        var csvContent = GenerateCsvContentOnline(datas);

    //        // Prepare the file content for download
    //        var data = Encoding.UTF8.GetBytes(csvContent);

    //        // Initiate the file download using FileSaver
    //        await JSRuntime.InvokeVoidAsync("saveAsFile", "OnlineAgent.csv", data, "text/csv");
    //        //ticketData = ticketData1;
    //    }


        private string GenerateCsvContentOnline(IEnumerable<DeviceDetailsDtoss> data)
        {
            // Generate CSV content based on your data structure
            StringBuilder csvContent = new StringBuilder();

            // Add header row
            var headers = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.Name);
            csvContent.AppendLine(string.Join(",", headers));

            // Add data rows
            foreach (var item in data)
            {
                var values = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }


    //    private async Task DownloadCsvOffline()
    //    {

    //        List<DeviceDetailsDtoss> datas = new List<DeviceDetailsDtoss>();
    //        offdevices.ToList().ForEach(x =>
    //        {
    //            DeviceDetailsDtoss data = new DeviceDetailsDtoss();
    //            data.Id = x.properties.Id;
    //            data.IsDeleted = x.properties.IsDeleted;
    //            data.entity_type = x.entity_type;
    //            data.SubType = x.properties.SubType;
    //            //data.LastUpdateTime = x.properties.LastUpdateTime;
    //            data.DisplayLabel = x.properties?.DisplayLabel;
    //            data.MfDeviceId = x.properties.MfDeviceId;
    //            data.IpAddress = x.properties.IpAddress;
    //            data.MacAddress = x.properties.MacAddress;
    //            data.AgentVersion = x.properties.AgentVersion;
    //            data.Location = x.properties.Location;
    //            data.Status = x.properties.Status;


				//// Convert long to DateTime
				//if (x.properties.LastUpdateTime.ToString().Length <= 10)
				//{
				//	DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeSeconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

				//	data.LastUpdateTime = resolvedDateTime.DateTime;
				//}
				//else
				//{
				//	DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

				//	data.LastUpdateTime = resolvedDateTime.DateTime;
				//}// Format DateTime as string
				// //string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");

				//// Now 'formattedDate' contains the desired string representation of the resolved date

				//datas.Add(data);



    //        });
    //        // Generate CSV content based on ticketData
    //        var csvContent = GenerateCsvContentOffline(datas);

    //        // Prepare the file content for download
    //        var data = Encoding.UTF8.GetBytes(csvContent);

    //        // Initiate the file download using FileSaver
    //        await JSRuntime.InvokeVoidAsync("saveAsFile", "OfflineAgent.csv", data, "text/csv");
    //        //ticketData = ticketData1;
    //    }


        private string GenerateCsvContentOffline(IEnumerable<DeviceDetailsDtoss> data)
        {
            // Generate CSV content based on your data structure
            StringBuilder csvContent = new StringBuilder();

            // Add header row
            var headers = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.Name);
            csvContent.AppendLine(string.Join(",", headers));

            // Add data rows
            foreach (var item in data)
            {
                var values = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }
        //private async Task DownloadCsvTotal()
        //{

        //    List<DeviceDetailsDtoss> datas = new List<DeviceDetailsDtoss>();
        //    Alldevices.ToList().ForEach(x =>
        //    {
        //        DeviceDetailsDtoss data = new DeviceDetailsDtoss();
        //        data.Id = x.properties.Id;
        //        data.IsDeleted = x.properties.IsDeleted;
        //        data.entity_type = x.entity_type;
        //        data.SubType = x.properties.SubType;
        //        //data.LastUpdateTime = x.properties.LastUpdateTime;
        //        data.DisplayLabel = x.properties?.DisplayLabel;
        //        data.MfDeviceId = x.properties.MfDeviceId;
        //        data.IpAddress = x.properties.IpAddress;
        //        data.MacAddress = x.properties.MacAddress;
        //        data.AgentVersion = x.properties.AgentVersion;
        //        data.Location = x.properties.Location;
        //        data.Status = x.properties.Status;


        //        // Convert long to DateTime
        //        if (x.properties.LastUpdateTime.ToString().Length <= 10)
        //        {
        //            DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeSeconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

        //            data.LastUpdateTime = resolvedDateTime.DateTime;
        //        }
        //        else
        //        {
        //            DateTimeOffset resolvedDateTime = DateTimeOffset.FromUnixTimeMilliseconds(x.properties.LastUpdateTime).UtcDateTime.AddHours(5).AddMinutes(30);

        //            data.LastUpdateTime = resolvedDateTime.DateTime;
        //        }// Format DateTime as string
        //         //string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");

        //        // Now 'formattedDate' contains the desired string representation of the resolved date

        //        datas.Add(data);



        //    });
        //    // Generate CSV content based on ticketData
        //    var csvContent = GenerateCsvContentTotal(datas);

        //    // Prepare the file content for download
        //    var data = Encoding.UTF8.GetBytes(csvContent);

        //    // Initiate the file download using FileSaver
        //    await JSRuntime.InvokeVoidAsync("saveAsFile", "TotalAgent.csv", data, "text/csv");
        //    //ticketData = ticketData1;
        //}
        private string GenerateCsvContentTotal(IEnumerable<DeviceDetailsDtoss> data)
        {
            // Generate CSV content based on your data structure
            StringBuilder csvContent = new StringBuilder();

            // Add header row
            var headers = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.Name);
            csvContent.AppendLine(string.Join(",", headers));

            // Add data rows
            foreach (var item in data)
            {
                var values = typeof(DeviceDetailsDtoss).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }
    }
}

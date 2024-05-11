using System.Text;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using custos.Models;
using custos.Models.SystemInfo;
using custos.Models.Master;

namespace custos.Web.Components.Pages
{
	public partial class SystemInfo
	{
		Variant variant = Variant.Filled;
		IEnumerable<RegisterDeviceDto> _systeminfo { get; set; }

		bool loading { get; set; } = true;
		IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };
		List<DeviceStatusPool> devicedata { get; set; } = new List<DeviceStatusPool>();
		List<DeviceStatusPool> onlinedevicedata { get; set; } = new List<DeviceStatusPool>();
		List<DeviceStatusPool> offlinedevicedata { get; set; } = new List<DeviceStatusPool>();

		protected override async Task OnInitializedAsync()
		{
			if (sessionData.UserData == null || sessionData.UserData.UserName == null)
				NavigationManager.NavigateTo("/");

			await base.OnInitializedAsync();

			await LoadData();
            await DeviceStatusData();



        }
		private async Task LoadData()
		{
			try
			{
				var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetRegisterDevice");
				if (output != null && output.Status == "Success")
				{
					_systeminfo = JsonConvert.DeserializeObject<IEnumerable<RegisterDeviceDto>>(output.Data.ToString());
					loading = false;

				}
			}
			catch(Exception ex)
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
                    onlinedevicedata = devicedata.FindAll(x => x.IsRunning == true).ToList();
                    offlinedevicedata = devicedata.FindAll(x => x.IsRunning == false).ToList();
                    foreach (var dev in _systeminfo)
                    {
                        foreach (var rundev in onlinedevicedata)
                        {
                            if (rundev.DeviceId.ToLower().Equals(dev.DisplayLabel!.ToLower()))
                            {
                                dev.Status = "Running";
                            }
                        }
                    }

                    foreach (var dev in _systeminfo)
                    {
                        foreach (var rundev in offlinedevicedata)
                        {
                            if (rundev.DeviceId.ToLower().Equals(dev.DisplayLabel!.ToLower()))
                            {
                                dev.Status = "Offline";
                            }
                        }
                    }
                }
				
            }
            catch (Exception ex) { }
			StateHasChanged();
        }




		private async Task DownloadCsvWindows()
		{
			// Generate CSV content based on ticketData
			var csvContent = GenerateCsvContent((IEnumerable<RegisterDeviceDto>)_systeminfo);

			// Prepare the file content for download
			var data = Encoding.UTF8.GetBytes(csvContent);

			// Initiate the file download using FileSaver
			await JSRuntime.InvokeVoidAsync("saveAsFile", "Systeminfo.csv", data, "text/csv");
			//ticketData = ticketData1;
		}





        private string GenerateCsvContent(IEnumerable<RegisterDeviceDto> data)
        {
            // Generate CSV content based on your data structure
            StringBuilder csvContent = new StringBuilder();

            // Use reflection to get properties only once
            var properties = typeof(RegisterDeviceDto).GetProperties();

            // Add header row
            var headers = properties.Select(property => property.Name);
            csvContent.AppendLine(string.Join(",", headers.Select(header => $"\"{header}\"")));

            // Add data rows
            foreach (var item in data)
            {
                var values = properties.Select(property =>
                {
                    var value = property.GetValue(item)?.ToString() ?? "";

                    // Replace newlines with \r\n and escape double quotes by doubling them
                    value = value.Replace("\n", "\r\n").Replace("\"", "\"\"");

                    // Enclose the value in double quotes to handle commas, newlines, and double quotes within the cell text
                    return $"\"{value}\"";
                });

                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }

    }
	}

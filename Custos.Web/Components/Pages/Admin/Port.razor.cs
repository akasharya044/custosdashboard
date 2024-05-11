using custos.Models.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Runtime.CompilerServices;
using System.Text;




namespace custos.Web.Components.Pages.Admin
{
    public partial class Port
    {
        Variant variant = Variant.Filled;
        public IBrowserFile? SelectedFile { get; private set; }
        List<PortInformationDto> _port { get; set; } = new List<PortInformationDto>();
        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };

        



        protected override async Task OnInitializedAsync()
        {
            if (sessionData.UserData == null || sessionData.UserData.UserName == null)
                NavigationManager.NavigateTo("/");

            await base.OnInitializedAsync();

            await LoadData();

            // Start a timer to refresh data every 60 seconds
            Timer timer = new Timer(async (_) => await RefreshData(), null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
        }


        private async Task LoadData()
        {
            var output = await custosapiservice.GetData("/api/portInformation/getportInformation");
            if (output != null && output.Status == "Success")
            {
                _port = JsonConvert.DeserializeObject<List<PortInformationDto>>(output.Data.ToString());
                _port = _port.DistinctBy(x=>x.SystemId).ToList();


            }

            loading = false;
            await InvokeAsync(StateHasChanged);
        }

        private async Task RefreshData()
        {
            await InvokeAsync(LoadData);
        }


        private async Task ShowEvenList(string user)
        {
            NavigationManager.NavigateTo("/portlist/" + user);
        }

        private async Task DownloadCsvPort()
        {
            try
            {
                // Generate CSV content based on ticketData
                var csvContent = GenerateCsvContentinstalled(_port);

                // Prepare the file content for download
                var data = Encoding.UTF8.GetBytes(csvContent);

                // Initiate the file download using FileSaver
                await JSRuntime.InvokeVoidAsync("saveAsFile", "Port.csv", data, "text/csv");
                //ticketData = ticketData1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private string GenerateCsvContentinstalled(List<PortInformationDto> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(PortInformationDto).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(PortInformationDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                    csvContent.AppendLine(string.Join(",", values));
                }

                return csvContent.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

    }
}

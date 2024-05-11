using custos.Models.DTO;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Text;

namespace custos.Web.Components.Pages
{
    public partial class InstalledSoftware
    {
        Variant variant = Variant.Filled;

        //List<HardwareInformationDto> _SystemHardware { get; set; } = new List<HardwareInformationDto>();
        List<InstalledSoftwareDto> _installed { get; set; } = new List<InstalledSoftwareDto>();
        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };

        protected override async Task OnInitializedAsync()
        {
            if (sessionData.UserData == null || sessionData.UserData.UserName == null)
                NavigationManager.NavigateTo("/");

            await base.OnInitializedAsync();
            await LoadData();
        }
        private async Task LoadData()
        {
            try
            {
                var output = await custosapiservice.GetData("/api/installedSoftware/getinstalledSoftwareInformation");
                if (output != null && output.Status == "Success")
                {
                    _installed = JsonConvert.DeserializeObject<List<InstalledSoftwareDto>>(output.Data.ToString());
                    _installed = _installed.DistinctBy(x=>x.SystemId).ToList();
                    loading = false;
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task ShowEvenList(string user)
        {
            NavigationManager.NavigateTo("/softlist/" + user);
        }


        private async Task DownloadCsvSoftware()
        {
            // Generate CSV content based on ticketData
            var csvContent = GenerateCsvContentinstalled(_installed);

            // Prepare the file content for download
            var data = Encoding.UTF8.GetBytes(csvContent);

            // Initiate the file download using FileSaver
            await JSRuntime.InvokeVoidAsync("saveAsFile", "InstalledSoftware.csv", data, "text/csv");
            //ticketData = ticketData1;
        }


        private string GenerateCsvContentinstalled(List<InstalledSoftwareDto> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(InstalledSoftwareDto).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(InstalledSoftwareDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
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

using custos.Models;
using custos.Models.DTO;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Text;


namespace custos.Web.Components.Pages.Admin
{
    

    public partial class SystemSoftware
    {
        Variant variant = Variant.Filled;

        List<SoftwareInformationDto> _SystemSoftware { get; set; } = new List<SoftwareInformationDto>();
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
                System.Threading.Thread.Sleep(2000);
                var output = await custosapiservice.GetData("/api/systemInformation/getsoftwareinfo");
                if (output != null && output.Status == "Success")
                {
                    _SystemSoftware = JsonConvert.DeserializeObject<List<SoftwareInformationDto>>(output.Data.ToString());
                    _SystemSoftware = _SystemSoftware.DistinctBy(x=>x.SystemId).ToList();
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
            NavigationManager.NavigateTo("/systemsoftwarelist/" + user);
        }

        private async Task DownloadCsvSoftware()
        {
            // Generate CSV content based on ticketData
            var csvContent = GenerateCsvContentinstalled(_SystemSoftware);

            // Prepare the file content for download
            var data = Encoding.UTF8.GetBytes(csvContent);

            // Initiate the file download using FileSaver
            await JSRuntime.InvokeVoidAsync("saveAsFile", "SoftwareInfo.csv", data, "text/csv");
            //ticketData = ticketData1;
        }


        private string GenerateCsvContentinstalled(IEnumerable<SoftwareInformationDto> data)
        {
            // Generate CSV content based on your data structure
            StringBuilder csvContent = new StringBuilder();

            // Add header row
            var headers = typeof(SoftwareInformationDto).GetProperties().Select(property => property.Name);
            csvContent.AppendLine(string.Join(",", headers));

            // Add data rows
            foreach (var item in data)
            {
                var values = typeof(SoftwareInformationDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }
    }
}

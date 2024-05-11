using custos.Models.DTO;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Text;

namespace custos.Web.Components.Pages.Wincore
{
    public partial class OS
    {
        Variant variant = Variant.Filled;

        //List<HardwareInformationDto> _SystemHardware { get; set; } = new List<HardwareInformationDto>();
List<OperatindSystemDto> _operating {  get; set; }=new List<OperatindSystemDto>();
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
                var output = await custosapiservice.GetData("/api/operatingSystem/getOperatingSystemInformation");
                if (output != null && output.Status == "Success")
                {
                    _operating = JsonConvert.DeserializeObject<List<OperatindSystemDto>>(output.Data.ToString());
                    loading = false;
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private async Task DownloadCsvWindows()
        {
            // Generate CSV content based on ticketData
            var csvContent = GenerateCsvContentinstalled(_operating);

            // Prepare the file content for download
            var data = Encoding.UTF8.GetBytes(csvContent);

            // Initiate the file download using FileSaver
            await JSRuntime.InvokeVoidAsync("saveAsFile", "WindowsInfo.csv", data, "text/csv");
            //ticketData = ticketData1;
        }


        
        private string GenerateCsvContentinstalled(List<OperatindSystemDto> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(OperatindSystemDto).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(OperatindSystemDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
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

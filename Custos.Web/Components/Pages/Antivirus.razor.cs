using custos.Models.DTO;
using custos.Web.Components.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Text;

namespace custos.Web.Components.Pages
{
    public partial class Antivirus
    {
        Variant variant = Variant.Filled;

        //List<HardwareInformationDto> _SystemHardware { get; set; } = new List<HardwareInformationDto>();
        List<AntivirusDetailsDto> _antivirus { get; set; } = new List<AntivirusDetailsDto>();
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
                var output = await custosapiservice.GetData("/api/antivirusInformation/getantivirusInformation");
                if (output != null && output.Status == "Success")
                {
                    _antivirus = JsonConvert.DeserializeObject<List<AntivirusDetailsDto>>(output.Data.ToString());
                    loading = false;
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private async Task DownloadCsvBackground()
        {
            try
            {
                // Generate CSV content based on ticketData
                var csvContent = GenerateCsvContentinstalled(_antivirus);

                // Prepare the file content for download
                var data = Encoding.UTF8.GetBytes(csvContent);

                // Initiate the file download using FileSaver
                await JSRuntime.InvokeVoidAsync("saveAsFile", "Antivirus.csv", data, "text/csv");
                //ticketData = ticketData1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private string GenerateCsvContentinstalled(List<AntivirusDetailsDto> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(AntivirusDetailsDto).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(AntivirusDetailsDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
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
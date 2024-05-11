using custos.Models;
using custos.Models.DTO;
using custos.Web.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OfficeOpenXml;
using Radzen;
using System.Text;



namespace custos.Web.Components.Pages
{
    public partial class Background
    {

        Variant variant = Variant.Filled;
        public IBrowserFile? SelectedFile { get; private set; }
        List<BackgroundserviceDTO> _background { get; set; } = new List<BackgroundserviceDTO>();
        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };

        private int threshold = 80;

        protected override async Task OnInitializedAsync()
        {
            if (sessionData.UserData == null || sessionData.UserData.UserName == null)
                NavigationManager.NavigateTo("/");

            await base.OnInitializedAsync();

            await LoadData();

            // Start a timer to refresh data every 60 seconds
            Timer timer = new Timer(async (_) => await RefreshData(), null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private async Task LoadData()
        {
            var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetBackgroundData");
            if (output != null && output.Status == "Success")
            {
                _background = JsonConvert.DeserializeObject<List<BackgroundserviceDTO>>(output.Data.ToString());
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
            NavigationManager.NavigateTo("/backgroundprogram/" + user);
        }



        private async Task DownloadCsvBackground()
        {
            try
            {
                // Generate CSV content based on ticketData
                var csvContent = GenerateCsvContentinstalled(_background);

                // Prepare the file content for download
                var data = Encoding.UTF8.GetBytes(csvContent);

                // Initiate the file download using FileSaver
                await JSRuntime.InvokeVoidAsync("saveAsFile", "BackgroudActivity.csv", data, "text/csv");
                //ticketData = ticketData1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private string GenerateCsvContentinstalled(List<BackgroundserviceDTO> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(BackgroundserviceDTO).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(BackgroundserviceDTO).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
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


//await JSRuntime.InvokeVoidAsync("alert", "Data exceeds threshold!");

//_background = _background.Where(x => x.UserId == System.Environment.MachineName).ToList();
//_background = _background.Where(x => x.MemoryUsages >= threshold || x.CpuUsgaes >= threshold || x.NetworkUsgaes >= threshold).ToList();
//if (_background.Any())
//{
//    await dialogService.Alert("alert", "Data exceeds threshold!");
//}
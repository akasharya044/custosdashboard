

using custos.Models.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Runtime.CompilerServices;
using System.Text;
namespace custos.Web.Components.Pages
{
    public partial class WindowsServiceList
    {


        Variant variant = Variant.Filled;
        public IBrowserFile? SelectedFile { get; private set; }
        List<WindowServicesDto> _win { get; set; } = new List<WindowServicesDto>();
        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };
        [Parameter]
        public string user { get; set; }

        private int threshold = 80;



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
            var output = await custosapiservice.GetData("/api/windowservices/getwindoeServiceInformationById?userid=" + user);

            if (output != null && output.Status == "Success")
            {
                _win = JsonConvert.DeserializeObject<List<WindowServicesDto>>(output.Data.ToString());
                _win = _win.DistinctBy(x => x.ServiceName).ToList();
            }

            loading = false;
            await InvokeAsync(StateHasChanged);
        }

        private async Task RefreshData()
        {
            await InvokeAsync(LoadData);
        }



        private async Task DownloadCsvBackground()
        {
            try
            {
                // Generate CSV content based on ticketData
                var csvContent = GenerateCsvContentinstalled(_win);

                // Prepare the file content for download
                var data = Encoding.UTF8.GetBytes(csvContent);

                // Initiate the file download using FileSaver
                await JSRuntime.InvokeVoidAsync("saveAsFile", user + " WinService Activity.csv", data, "text/csv");
                //ticketData = ticketData1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private string GenerateCsvContentinstalled(List<WindowServicesDto> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(WindowServicesDto).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(WindowServicesDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
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


using custos.Models.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Radzen;
using System.Runtime.CompilerServices;
using System.Text;

namespace custos.Web.Components.Pages
{


    public partial class Program
    {


        Variant variant = Variant.Filled;
        public IBrowserFile? SelectedFile { get; private set; }
        List<ProgramDataDto> _backgroundprogram { get; set; } = new List<ProgramDataDto>();
        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };
        [Parameter]
        public string user { get; set; }

        private int threshold = 80;

        public string programname { get; set; } = string.Empty;

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
            var output = await custosapiservice.GetData("/api/additional/additionalinfo/getProgramdataById?userid="+user);

            if (output != null && output.Status == "Success")
            {
                _backgroundprogram = JsonConvert.DeserializeObject<List<ProgramDataDto>>(output.Data.ToString());
                _backgroundprogram = _backgroundprogram.DistinctBy(x => x.ProgramNames).ToList();
            }
            if (programname != "")
            {
                _backgroundprogram = _backgroundprogram.Where(x => x.ProgramNames != programname).ToList();

            }

            loading = false;
            await InvokeAsync(StateHasChanged);
        }

        private async Task RefreshData()
        {
            await InvokeAsync(LoadData);
        }

        private async Task KillProgram(string ProcessName, string systemid)
        {

            programname = ProcessName;
            
            Command command = new Command();
            await command.RabbitSendCommand("101", systemid, programname, "", "", 0, null);

        }

        private async Task DownloadCsvBackground()
        {
            try
            {
                // Generate CSV content based on ticketData
                var csvContent = GenerateCsvContentinstalled(_backgroundprogram);

                // Prepare the file content for download
                var data = Encoding.UTF8.GetBytes(csvContent);

                // Initiate the file download using FileSaver
                await JSRuntime.InvokeVoidAsync("saveAsFile", user + " BackgroudActivity.csv", data, "text/csv");
                //ticketData = ticketData1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private string GenerateCsvContentinstalled(List<ProgramDataDto> data)
        {
            try
            {
                // Generate CSV content based on your data structure
                StringBuilder csvContent = new StringBuilder();

                // Add header row
                var headers = typeof(ProgramDataDto).GetProperties().Select(property => property.Name);
                csvContent.AppendLine(string.Join(",", headers));

                // Add data rows
                foreach (var item in data)
                {
                    var values = typeof(ProgramDataDto).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
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

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

    public partial class Alert
    {

        Variant variant = Variant.Filled;
        public IBrowserFile? SelectedFile { get; private set; }
        List<BackgroundserviceDTO> _background { get; set; } = new List<BackgroundserviceDTO>();
        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };

        private int threshold = 99;
        // public static int count { get; set; }

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
            var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetBackgroundData");
            if (output != null && output.Status == "Success")
            {
                _background = JsonConvert.DeserializeObject<List<BackgroundserviceDTO>>(output.Data.ToString());
                _background = _background.Where(x => x.MemoryUsages >= threshold).ToList();
                NotyCount.Count = _background.Count();

                if (_background.Count > 10)
                {
                    for (int i = 0; i <= 4; i--)
                    {
                        _background.RemoveAt(i);
                    }



                }

                loading = false;
                await InvokeAsync(StateHasChanged);
            }

           

        }
        private async Task RefreshData()
        {
            await InvokeAsync(LoadData);
        }
    }
}

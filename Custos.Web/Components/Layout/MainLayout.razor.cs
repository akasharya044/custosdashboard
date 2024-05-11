using custos.Models.DTO;
using custos.Web.Components.Pages;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Runtime.CompilerServices;

namespace custos.Web.Components.Layout
{
    public partial class MainLayout
    {
        public int threshold = 90;
        static DialogPosition position;
        static bool closeDialogOnOverlayClick;
        static bool showMask;

        public static  int Notcount {get; set;}
        List<BackgroundserviceDTO> _background { get; set; } = new List<BackgroundserviceDTO>();
        protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
            await NotiCountAsync();
            Timer timer = new Timer(async (_) => await RefreshData(), null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            

        }
        private async Task RefreshData()
        {
            await InvokeAsync(NotiCountAsync);
        }

        private async Task ToggleSideBar()
        {
            await JSRuntime.InvokeVoidAsync("sideBarToggle");
        }
        public async Task OpenSideDialog()
        {
            await dialogService.OpenSideAsync<Alert>("Notification", options: new SideDialogOptions { CloseDialogOnOverlayClick = closeDialogOnOverlayClick, Position = position, ShowMask = showMask });

        }

        public async Task NotiCountAsync()
        {
            var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetBackgroundData");
            if (output != null && output.Status == "Success")
            {
                _background = JsonConvert.DeserializeObject<List<BackgroundserviceDTO>>(output.Data.ToString());
                _background = _background.Where(x => x.MemoryUsages >= threshold).ToList();
                Notcount = _background.Count();

            }
            await InvokeAsync(StateHasChanged);


        }

        



    }
}


//using Newtonsoft.Json;
//using Radzen.Blazor;

//namespace custos.Web.Components.Pages;

//public partial class CSATSetting
//{
//    public List<CsatSetting> csatsetting = new List<CsatSetting>();
//    public List<CsatSettingDto> csatsettingdto = new List<CsatSettingDto>();
//    public bool IsRead { get; set; } = false;
//    public bool IsEdit { get; set; } = false;
//	RadzenDataGrid<CsatSettingDto> _refcsat;


//	protected override async Task OnInitializedAsync()
//    {
//        await base.OnInitializedAsync();
//        await GetData();
//        StateHasChanged();
//    }
//    public async Task UpsertData(CsatSettingDto csat)
//    {
//        CsatSetting csatSetting = new CsatSetting();
//        if (csat.FeedbackPopupTime <= 0)
//        {
//            dialogService.Alert("Duration Should be greater than Zero.");
//            return;
//        }
//        csatSetting.Id = csat.Id;
//        csatSetting.Name = csat.Name;
//        csatSetting.FeedbackPopupTime = csat.FeedbackPopupTime;
//        var response = await custosapiservice.PostData(csatSetting, "/api/csatsetting");
//        if (response != null && response.Status == "Success")
//        {
//            await GetData();
//            IsEdit = false;
//            StateHasChanged();
//        }
//        else
//        {
//            await dialogService.Alert(response.Message, "Error");
//        }
//    }
//    public async Task GetData()
//    {
//        csatsettingdto = new List<CsatSettingDto>();
//		var response = await custosapiservice.GetData("/api/csatsetting");
//        if (response != null && response.Status == "Success")
//        {
//            csatsetting = JsonConvert.DeserializeObject<List<CsatSetting>>(response.Data.ToString());
//            csatsetting.ForEach(x =>
//            {
//                CsatSettingDto csat = new CsatSettingDto();
//                csat.Id = x.Id;
//                csat.Name = x.Name;
//                csat.FeedbackPopupTime = x.FeedbackPopupTime;
//                csat.UpdatedDate = x.UpdatedDate;
//                csat.CreatedDate = x.CreatedDate;
//                csatsettingdto.Add(csat);
//            });
//			_refcsat.Reset();

//			StateHasChanged();
//        }
//        else
//        {
//            await dialogService.Alert(response.Message, "Error");
//        }
//    }
//    private async void EditRecord(CsatSettingDto csat)
//    {
//        csat.IsEdit=true;
//        IsEdit = true;

//    }
//}

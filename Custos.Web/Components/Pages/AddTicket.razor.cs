using System.Runtime.CompilerServices;
using custos.Models;
using custos.Models.Tickets;
using custos.Modelss;
using Newtonsoft.Json;

namespace custos.Web.Components.Pages
{
	public partial class AddTicket
	{
		TicketDto ticketDto = new TicketDto();

		List<SubCategoriesDto> _subCategories = new List<SubCategoriesDto>();
		List<CategoriesDto> _categories { get; set; } = new List<CategoriesDto>();
		List<AreaDTO> _arealist { get; set; } = new List<AreaDTO>();

		DeviceDetailDto deviceDetailDtos = new DeviceDetailDto();

		PersonDetailsDto personDetailsDtos = new PersonDetailsDto();
		List<PersonDetailsDto> personDetails { get; set; } = new List<PersonDetailsDto>();
		List<DeviceDetailDto> deviceDetails { get; set; } = new List<DeviceDetailDto>();



		protected override async Task OnInitializedAsync()
		{
			if (sessionData.UserData == null || sessionData.UserData.UserName == null)
				NavigationManager.NavigateTo("/");

			await base.OnInitializedAsync();

			await CategoriesData();
			await DeviceDetailsData();
			await PersonDetailsData();


		}
		private async Task CategoriesData()
		{

			var output = await custosapiservice.GetData("/api/categories");
			if (output != null && output.Status == "Success")
			{
				_categories = JsonConvert.DeserializeObject<List<CategoriesDto>>(output.Data.ToString());
			}
		}
		private async Task SubCategoriesData(int Id)
		{

			var output = await custosapiservice.GetData("api/subcategories?CategoryId=" + Id);
			if (output != null && output.Status == "Success")
			{
				_subCategories = JsonConvert.DeserializeObject<List<SubCategoriesDto>>(output.Data.ToString());
			}
		}
		private async Task AreaData(int CatId, int SubCatId)
		{


			var output = await custosapiservice.GetData("api/area/areas?categoryId=" + CatId + "&SubcategoryId=" + SubCatId);
			if (output != null && output.Status == "success")
			{
				_arealist = JsonConvert.DeserializeObject<List<AreaDTO>>(output.Data.ToString());
			}
		}
		private async Task DeviceDetailsData()
		{
			var output = await custosapiservice.GetData("api/devicedetails/device/");
			if (output != null && output.Status == "Success")
			{
				deviceDetails = JsonConvert.DeserializeObject<List<DeviceDetailDto>>(output.Data.ToString());
			}
		}
		private async Task PersonDetailsData()
		{
			var output = await custosapiservice.GetData("api/persondetails/");
			if (output != null && output.Status == "Success")
			{
				personDetails = JsonConvert.DeserializeObject<List<PersonDetailsDto>>(output.Data.ToString());
			}
		}

		private async Task UpsertData()
		{
			try
			{
				var response = await custosapiservice.PostData(ticketDto, "/api/ticketrecords");
				if (response != null && response.Status == "Success")
				{
					dialogService.Alert("Data is saved");
				}
				else
				{
					dialogService.Alert("Data is not saved");
				}

			}
			catch (Exception ex)
			{
				dialogService.Close();

			}
			NavigationManager.NavigateTo("/ticketinformation");

		}
	}
}

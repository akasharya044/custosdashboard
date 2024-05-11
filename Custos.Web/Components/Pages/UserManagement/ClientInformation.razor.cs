using custos.Models.RbacModel;
using Newtonsoft.Json;
using Radzen;
using Radzen.Blazor;

namespace custos.Web.Components.Pages.UserManagement
{
    public partial class ClientInformation
    {
		Variant variant = Variant.Filled;
		List<ClientDTO> clientDTOs = new List<ClientDTO>();



		RadzenDataGrid<ClientDTO> grid;

		bool loading { get; set; } = true;
		IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };


		protected override async Task OnInitializedAsync()
		{


			await base.OnInitializedAsync();

			await LoadData();


		}
		private void AddClientInformation()
		{
			NavigationManager.NavigateTo("/addclientinformation");

		}
		
		private async Task LoadData()
		{
			var output = await custosapiservice.GetData("/api/custos/users/");
			if (output != null && output.StatusCode == "Success")
			{
				clientDTOs = JsonConvert.DeserializeObject<List<ClientDTO>>(output.Data.ToString());
				loading = false;
			}
		}
		private async Task ShowList(Guid id)
		{
			var Id = id.ToString();

			NavigationManager.NavigateTo($"/clientlicenselist/{Id}");

		}


	}



}


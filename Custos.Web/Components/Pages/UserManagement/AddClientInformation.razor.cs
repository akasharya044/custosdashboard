using custos.Models.Master;
using custos.Models.RbacModel;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace custos.Web.Components.Pages.UserManagement
{
	public partial class AddClientInformation
	{

		ClientDTO clientDTO = new ClientDTO();

		List<State> _state { get; set; } = new List<State>();



		protected override async Task OnInitializedAsync()
        {


            await base.OnInitializedAsync();
			await StateData();
        }
		private async Task StateData()
		{

			var output = await custosapiservice.GetData("/api/custos/users/GetAllState");
			if (output != null && output.StatusCode == "Success")
			{
				_state = JsonConvert.DeserializeObject<List<State>>(output.Data.ToString());
			}
		}

		private async Task UpsertData()
		{
			try
			{
				var response = await custosapiservice.PostData(clientDTO, "/api/custos/users/createclient/");
				if (response != null && response.StatusCode == "Success")
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
			NavigationManager.NavigateTo("/clientinformation");

		}

	}
}
 
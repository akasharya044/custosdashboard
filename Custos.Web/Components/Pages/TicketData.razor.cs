using custos.Models;
using custos.Models;
using custos.Web.Components.Dto;
using custos.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OfficeOpenXml;
using Radzen;
using Radzen.Blazor;
using custos.Models;
using System.Text;
using custos.Models.Tickets;

namespace custos.Web.Components.Pages
{
	public partial class TicketData
	{
		Variant variant = Variant.Filled;
		List<TicketRecordDto> ticketRecordDtos = new List<TicketRecordDto>();

		List<TicketUpdateDto> UpdateTicketDto = new List<TicketUpdateDto>();


		RadzenDataGrid<TicketRecordDto> grid;

		bool loading { get; set; } = true;
		IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };


		protected override async Task OnInitializedAsync()
		{


			await base.OnInitializedAsync();

			await LoadData();


		}
		private void AddTicket()
		{
			NavigationManager.NavigateTo("/addticket");

		}
		private void EditTicket(int id)
		{

			NavigationManager.NavigateTo($"/UpdateTicket/{id}");
		}
		private async Task LoadData()
		{
			//var output = await custosapiservice.GetData("/api/tickets/getlist/");
			var output = await custosapiservice.GetData("/api/ticketrecords/getlist");
			if (output != null && output.Status == "Success")
			{
				ticketRecordDtos = JsonConvert.DeserializeObject<List<TicketRecordDto>>(output.Data.ToString());
				loading = false;
			}
		}

	}



}






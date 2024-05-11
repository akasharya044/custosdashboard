using System.Runtime.CompilerServices;
using custos.Models;
using custos.Models.Tickets;
using custos.Modelss;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OfficeOpenXml.Sorting;

namespace custos.Web.Components.Pages
{
	public partial class UpdateTicket
	{
		TicketDto ticketDto = new TicketDto();

		List<TicketRecordDto> ticketRecordDtos = new List<TicketRecordDto>();



		TicketUpdateDto UpdateTicketDto = new TicketUpdateDto();

		public List<AutoCompleteDto> _ticketStatusList { get; set; } = new List<AutoCompleteDto>
			{
				new AutoCompleteDto{Name="Pending",value=1},
				 new AutoCompleteDto{Name="Ticket Generated",value=0},
				 new AutoCompleteDto{Name = "Resolved", value =2},
				 new AutoCompleteDto{Name = "Completed", value = 3 }


			};





		//Dictionary<int, string> _ticketStatusList = new Dictionary<int, string>
		//{
		//    {0, "Ticket Generated"},
		//    {1, "Pending" },
		//    {2,"Resolved" },
		//    {3,"Completed" }
		//};

		[Parameter]
		public int id { get; set; }




		protected override async Task OnInitializedAsync()
		{
			if (sessionData.UserData == null || sessionData.UserData.UserName == null)
				NavigationManager.NavigateTo("/");

			await base.OnInitializedAsync();


			await LoadData();



		}
		private async Task LoadData()
		{


			var data = await custosapiservice.GetData($"/api/tickets?Id={id}");
			if (data != null && data.Status == "Success")
			{
				UpdateTicketDto = JsonConvert.DeserializeObject<TicketUpdateDto>(data.Data.ToString());

			}

		}
		private async Task UpdateUserData()
		{

			UpdateTicketDto.Id = id;
			if (UpdateTicketDto.TicketStatus == "Ticket Generated")
				UpdateTicketDto.Status = 0;
			if (UpdateTicketDto.TicketStatus == "Pending")
				UpdateTicketDto.Status = 1;
			if (UpdateTicketDto.TicketStatus == "Resolved")
				UpdateTicketDto.Status = 2;
			if (UpdateTicketDto.TicketStatus == "Completed")
				UpdateTicketDto.Status = 3;
			var output = await custosapiservice.PutData(UpdateTicketDto, $"api/ticketrecords");
			NavigationManager.NavigateTo($"/ticketinformation");
		}


	}
}

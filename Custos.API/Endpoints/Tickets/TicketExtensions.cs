using custos.DAL.DataService;
using custos.Models;
using custos.Models.Tickets;
using Custos.DAL.DataService;
using Microsoft.AspNetCore.Mvc;

namespace custos.API.Endpoints
{
    public static partial class TicketExtensions
    {
        public static async Task<IResult> GetList([FromServices]   IDataService dataService)
        {
            var response = await dataService.ticketdata.GetList();
            return Results.Ok(response);
        }
        public static async Task<IResult> GetTicketById([FromServices] IDataService dataService, int Id)
        {
            var response = await dataService.ticketdata.GetTicketById(Id);
            return Results.Ok(response);
        }
        public static async Task<IResult> AddTicket([FromBody] TicketDto ticketDto, IDataService dataService)
        {
            var response = await dataService.ticketdata.AddTicket(ticketDto);
            return Results.Ok(response);
        }
		public static async Task<IResult> UpdateTicket( TicketUpdateDto updateDto, IDataService dataService)
		{
			var response = await dataService.ticketdata.UpdateTicket(updateDto);
			return Results.Ok(response);
		}

	}
}

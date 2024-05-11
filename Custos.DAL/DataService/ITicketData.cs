using custos.Models;

using custos.Models.Tickets;

namespace custos.DAL.DataService
{
	public interface ITicketData
	{
		Task<Response> GetList();

		Task<Response> AddTicket(TicketDto ticketDto);

		Task<Response> UpdateTicket(TicketUpdateDto updateDto);

		Task<Response> GetTicketById(int ticketId);



	}
}
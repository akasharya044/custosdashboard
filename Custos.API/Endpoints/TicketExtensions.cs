
using custos.Models ;

namespace custos.API.Endpoints
{
    public static partial class TicketExtensions
    {
        public static RouteGroupBuilder MapTicketEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getlist", GetList);
            group.MapPost("", AddTicket);
            group.MapPut("", UpdateTicket);
            group.MapGet("", GetTicketById);

            return group;
        }
    }
}

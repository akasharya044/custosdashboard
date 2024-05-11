using custos.Models;

namespace Custos.DAL.DataService
{
	public interface IEventHistories
    {
        Task<Response> GetAllEventHistory();
		Task<Response> AddEventHistory(EventHistoryDto data);
		Task<Response> GetAllEventName(string eventname);

	}
}

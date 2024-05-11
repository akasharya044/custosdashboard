using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class EventHistoriesMapper :Profile
    {
        public EventHistoriesMapper()
        {
            CreateMap<EventHistory, EventHistoryDto>().ReverseMap();
        }
    }
}

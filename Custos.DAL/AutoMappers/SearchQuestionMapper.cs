using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{

	public class SearchQuestionMapper : Profile
    {
        public SearchQuestionMapper()
        {
            CreateMap<SearchQuestion, SearchQuestionDto>().ReverseMap();
        }
    }
}

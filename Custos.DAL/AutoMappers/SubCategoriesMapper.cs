using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class SubCategoriesMapper : Profile
	{
		public SubCategoriesMapper()
		{
			CreateMap<SubCategories, SubCategoriesDto>().ReverseMap();
			CreateMap<Questions, QuestionsDto>().ReverseMap();
			CreateMap<Questions, QuestionDto>().ReverseMap();
			CreateMap<Answers, AnswersDto>().ReverseMap();
            CreateMap<QuenstionAnswer, QuenstionAnswerDto>().ReverseMap();

        }
    }
}

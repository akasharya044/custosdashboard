using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class CategoriesMapper : Profile
	{
		public CategoriesMapper()
		{
			CreateMap<Categories,CategoriesDto>().ReverseMap();
		}
	}
}

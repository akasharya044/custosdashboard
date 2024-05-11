using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class AreaMappers : Profile
	{
		public AreaMappers()
		{
			CreateMap<Areas, AreaDTO>().ReverseMap();
		}
	}
}

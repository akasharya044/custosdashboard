using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class MachineRegistrationMapper : Profile
	{
		public MachineRegistrationMapper()
		{
			CreateMap<MachineRegistration, MachineRegistrationDto>().ReverseMap();
		}

	}
}

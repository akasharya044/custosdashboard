using AutoMapper;
using custos.Models.DTO;

namespace Custos.DAL.AutoMappers
{
	public class UserSystemSoftwareMapper : Profile
    {
        public UserSystemSoftwareMapper() 
        {
            CreateMap<SoftwareInformationDto,SoftwareInformation>().ReverseMap();
            CreateMap<HardwareInformation, HardwareInformationDto>().ReverseMap();
        }

    }
}

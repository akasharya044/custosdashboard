using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class AdminMapper : Profile
	{
		public AdminMapper()
		{
	
			CreateMap<AdminUsers, AdminUsersDto>()
			  .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.Name)).ReverseMap();

			CreateMap<AdditionalInformation, AdditionalInformationDTO>()

			.ReverseMap();
			CreateMap<AdditionalInformationHardDisk, AdditionalInformationHardDiskDto>().ReverseMap();


			CreateMap<DeviceData, DeviceDataDto>().ReverseMap();
		}
	}
}

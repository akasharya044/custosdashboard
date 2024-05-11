using AutoMapper;
using custos.Models;

namespace Custos.DAL.AutoMappers
{
	public class DeviceDetailsMapper : Profile
	{
		public DeviceDetailsMapper()
		{
			//CreateMap<DeviceDetails, DeviceDetailsDto>()
			//	.ForPath(dest => dest.properties.Id, src => src.MapFrom(x => x.Id))
			//	.ForPath(dest => dest.properties.SubType, src => src.MapFrom(x => x.SubType))
			//	.ForPath(dest => dest.properties.DisplayLabel, src => src.MapFrom(x => x.DisplayLabel))
			//	.ForPath(dest => dest.properties.LastUpdateTime, src => src.MapFrom(x => x.LastUpdateTime))
			//	.ForPath(dest => dest.properties.IpAddress, src => src.MapFrom(x => x.IpAddress))
			//	.ForPath(dest => dest.properties.MacAddress, src => src.MapFrom(x => x.MacAddress))
			//	.ForPath(dest => dest.properties.AgentVersion, src => src.MapFrom(x => x.AgentVersion))
			//	.ReverseMap();

			CreateMap<DeviceRunningLog,DeviceRunningLogDTO>().ReverseMap();

		}
	}
}

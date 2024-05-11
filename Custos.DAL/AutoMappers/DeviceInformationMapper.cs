
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models.DTO;
using AutoMapper;

namespace custos.DAL.AutoMappers
{
    public class DeviceInformationMapper:Profile
    {
        public DeviceInformationMapper()
        {
            CreateMap<DeviceDetailsDTO, DeviceDetails>().ReverseMap();
        }
    }
}

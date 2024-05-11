using AutoMapper;
using custos.Models.DTO;
using custos.Models.SystemInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public class RegisterdeviceMapper:Profile
    {
        public RegisterdeviceMapper()
        {
            CreateMap<RegisterDevice, RegisterDeviceDto>().ReverseMap();
        }
    
}
}

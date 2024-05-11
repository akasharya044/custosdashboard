using AutoMapper;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public class PortInformationMapper:Profile
    {
        public PortInformationMapper()
        {
            CreateMap<PortInformationDto, PortInformation>().ReverseMap();
        }
    }
}

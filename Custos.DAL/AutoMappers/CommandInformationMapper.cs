using AutoMapper;
using custos.Models.AdditionalInfo;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public class CommandInformationMapper : Profile
    {
        public CommandInformationMapper()
        {
            CreateMap<CommandData, CommandDataDto>().ReverseMap();
        }
    }
}

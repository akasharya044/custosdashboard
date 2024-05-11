using AutoMapper;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public  class BackgroundThresholdMapper:Profile
    {
        public BackgroundThresholdMapper()
        {

            CreateMap<BackgroundThreshold, BackgroundThresholdDto>().ReverseMap();
        }
    }
}

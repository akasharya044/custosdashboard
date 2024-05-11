using AutoMapper;
using custos.Models;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public class WindowServicesMapper:Profile
    {
        public WindowServicesMapper()
        {
            CreateMap<WindowServicesDto,WindowServices>().ReverseMap();
        }
    }
}

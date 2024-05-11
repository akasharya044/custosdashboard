using AutoMapper;
using custos.Models;
using custos.Models.RbacModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public class RbacDataMapper : Profile
    {
        public RbacDataMapper()
        {

            CreateMap<UserType, UserTypeDTO>().ReverseMap();

            CreateMap<Client, ClientDTO>().ReverseMap();

			CreateMap<ClientLicense, ClientLicenseDTO>().ReverseMap();

		}
	}
}
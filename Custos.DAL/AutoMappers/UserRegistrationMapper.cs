using AutoMapper;
using custos.Models.UserRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.AutoMappers
{
    public class UserRegistrationMapper : Profile
    {
        public UserRegistrationMapper()
        {
            CreateMap<UserRegistrations, UserRegistrationDto>().ReverseMap();
            CreateMap<Key, KeyDTO>().ReverseMap();

        }

    }
}

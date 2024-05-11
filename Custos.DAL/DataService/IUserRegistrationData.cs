using custos.Models;
using custos.Models.UserRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public interface IUserRegistrationData
    {
        Task<Response> GetRegistration(string systemid);

        Task<Response> AddRegistraton(UserRegistrationDto userDto);

        Task<Response> AddKey(KeyDTO key);

        Task<Key> GetKey(string key);


    }
}

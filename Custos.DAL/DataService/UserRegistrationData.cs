using AutoMapper;
using custos.Models;
using custos.Models.Tickets;
using custos.Models.UserRegistration;
using Custos.DAL.Unitofworks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public class UserRegistrationData :IUserRegistrationData
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;


        public UserRegistrationData(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

        }

        public async Task<Response> GetRegistration(string systemid)
        {
            Response response = new Response();
            try
            {
                var data = await _uow.userRegistraion.GetFirstOrDefaultAsync(x => x.SystemId == systemid);
                if (data != null)
                {
                    response.Status = "Success";
                    response.Message = "Data Fetch Successfully";
                    response.Data = data;
                }
                else
                {
                    response.Status = "Success";
                    response.Message = "No Record Found!!";
                }
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;
            }
            return response;

        }
        public async Task<Response> AddRegistraton(UserRegistrationDto userDto)
        {
            Response response = new Response();
            try
            {

                var mappedData = _mapper.Map<UserRegistrations>(userDto);
                var keyData = _uow.keyRegistration.GetFirstOrDefaultAsync(x => x.key == userDto.UniqueKey).Result;
                if (keyData == null)
                {
                    response.Status = "Failed";
                    response.Message = "Invalid_Key";
                }
                else
                {
                    if (keyData != null && keyData.status == false)
                    {
                        response.Status = "Failed";
                        response.Message = "Key_Already_Used";
                    }
                    else
                    {
                        mappedData.RegistrationDateTime = DateTime.Now;
                        mappedData.IsRegistered = true;
                        _uow.userRegistraion.Add(mappedData);

                        var keyvalue = _uow.keyRegistration.GetFirstOrDefaultAsync(x => x.key == userDto.UniqueKey).Result;
                        keyvalue.status = false;

                        _uow.keyRegistration.Update(keyvalue);
                        await _uow.SaveAsync();

                        response.Status = "Success";
                        response.Message = "Data Saved";
                    }
                    
                }

            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                var errorMessage = await _uow.AddException(ex);
                response.Message = errorMessage;
            }
            return response;
        }

        public async Task<Key> GetKey(string key)
        {
            var data = await _uow.keyRegistration.GetFirstOrDefaultAsync(x=>x.key==key);
            return data;

        }

        public async Task<Response> AddKey(KeyDTO key)
        {
            Response response = new Response();
            try
            {

                var mappedData = _mapper.Map<Key>(key);
               
                if (mappedData != null)
                {
                    _uow.keyRegistration.Add(mappedData);
                    await _uow.SaveAsync();

                    response.Status = "Success";
                    response.Message = "Data Saved";
                    response.Data = mappedData;
                }
                else
                {
                    response.Status = "Failed";
                    response.Message = "Not Saved";
                }

            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                var errorMessage = await _uow.AddException(ex);
                response.Message = errorMessage;
            }
            return response;
        }




    }
}

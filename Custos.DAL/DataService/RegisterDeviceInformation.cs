using AutoMapper;
using Custos.DAL.Unitofworks;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models;
using custos.Models.SystemInfo;

namespace custos.DAL.DataService
{
    public class RegisterDeviceInformation:IRegisterdevice
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public RegisterDeviceInformation(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> GetRegisterdeviceInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.registerdevice.GetAllAsync();
                if (data != null && data.Count() > 0)
                {
                    response.Status = "Success";
                    response.Message = "Data Fetch Successfully";
                    response.Data = data;
                }
                else
                {
                    response.Status = "Success";
                    response.Message = "No Record Found!!";
                    response.Data = data;
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
        public async Task<Response> AddRegisterdeviceInformation(RegisterDeviceDto data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<RegisterDevice>(data);
                var dbdata = await _uow.registerdevice.GetAllAsync(x => x.systemid == mappeddata.systemid);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.registerdevice.Update(mappeddata);
                    _uow.Save();
                }
                else
                {
                    await _uow.registerdevice.AddAsync(mappeddata);
                    await _uow.SaveAsync();
                }

                response.Status = "Success";
                response.Message = "Data Saved";
                response.Data = mappeddata;
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;

            }
            return response;
        }
        public async Task<Response> GetRegisterdeviceInformationById(string user)
        {
            Response response = new Response();
            try
            {
                var data = _uow.registerdevice.GetAll(x => x.systemid == user);
                var mapdata = _mapper.Map<List<RegisterDeviceDto>>(data);

                if (mapdata != null && mapdata.Count() > 0)
                {
                    response.Status = "Success";
                    response.Message = "Data Fetch Successfully";
                    response.Data = mapdata;
                }
                else
                {
                    response.Status = "Success";
                    response.Message = "No Record Found!!";
                    response.Data = mapdata;
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

    }
}

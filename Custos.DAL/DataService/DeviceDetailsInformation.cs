using AutoMapper;
using Custos.DAL.Unitofworks;
using custos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models.DTO;
using DeviceDetails = custos.Models.DTO.DeviceDetails;

namespace custos.DAL.DataService
{
    public class DeviceDetailsInformation:IDeviceDetailsInformation
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public DeviceDetailsInformation(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> GetDeviceInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.devicedetails.GetAllAsync();
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
        public async Task<Response> AddDeviceInformation(DeviceDetailsDTO data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<DeviceDetails>(data);
                var dbdata = await _uow.devicedetails.GetAllAsync(x => x.BIOS == mappeddata.BIOS);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.devicedetails.Update(mappeddata);
                    _uow.Save();
                }
                else
                {
                    await _uow.devicedetails.AddAsync(mappeddata);
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
    }
}


    


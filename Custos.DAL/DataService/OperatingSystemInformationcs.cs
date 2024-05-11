using AutoMapper;
using custos.Models;
using custos.Models.DTO;
using Custos.DAL.Unitofworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public class OperatingSystemInformation:IOperatingSystem
    {
        
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public OperatingSystemInformation(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> GetOperatingSystemInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.operatingsystem.GetAllAsync();
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
        public async Task<Response> AddOperatingSystemInformation(OperatindSystemDto data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<custos.Models.DTO.OperatingSystem1>(data);
                var dbdata = await _uow.operatingsystem.GetAllAsync(x => x.SerialNumber == mappeddata.SerialNumber);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.operatingsystem.Update(mappeddata);
                    _uow.Save();
                }
                else
                {
                    await _uow.operatingsystem.AddAsync(mappeddata);
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
    


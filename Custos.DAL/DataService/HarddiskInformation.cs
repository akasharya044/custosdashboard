using AutoMapper;
using Custos.DAL.Unitofworks;
using custos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models.DTO;
//using DeviceDetails = custos.Models.DTO.DeviceDetails;

namespace custos.DAL.DataService
{
    public class HarddiskInformation : IHarddiskInformation
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public HarddiskInformation(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> GetHarddiskInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.harddiskdetails.GetAllAsync();
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
        public async Task<Response> AddHarddiskInformation(HarddiskDetailsDto data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<HarddiskDetails>(data);
                var dbdata = await _uow.harddiskdetails.GetAllAsync(x => x.SystemId == mappeddata.SystemId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.harddiskdetails.Update(mappeddata);
                    _uow.Save();
                }
                else
                {
                    await _uow.harddiskdetails.AddAsync(mappeddata);
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





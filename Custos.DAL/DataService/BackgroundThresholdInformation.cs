using AutoMapper;
using Custos.DAL.Unitofworks;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models;

namespace custos.DAL.DataService
{
    public class BackgroundThresholdInformation:IBackgroundThreshold
    {

        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public BackgroundThresholdInformation(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> GetBackgroundThresholdInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.backgroundthreshold.GetAllAsync();
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
        public async Task<Response> AddBackgroundThresholdInformation(BackgroundThresholdDto data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<BackgroundThreshold>(data);
                var dbdata = await _uow.backgroundthreshold.GetAllAsync(x => x.Id == mappeddata.Id);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.backgroundthreshold.Update(mappeddata);
                    _uow.Save();
                }
                else
                {
                    await _uow.backgroundthreshold.AddAsync(mappeddata);
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

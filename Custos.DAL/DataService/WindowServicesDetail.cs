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
    public class WindowServicesDetail : IWindowServices
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public WindowServicesDetail(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> AddWindowServicesInformation(List<WindowServicesDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<WindowServices>>(data);
                var dbdata = await _uow.windowservices.GetAllAsync(x => x.SystemId == data.FirstOrDefault().SystemId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    dbdata.ToList().ForEach(x =>
                    {
                        var data = mappeddata.Find(y => y.ServiceName == x.ServiceName) != null ? mappeddata.FirstOrDefault(y => y.ServiceName == x.ServiceName)!.ServiceName : "";

                        if (data != "")
                        {
                            x.Startup = mappeddata.Find(y => y.ServiceName! == x.ServiceName!)!.Startup;
                            x.ServiceDisplayName = mappeddata.FirstOrDefault(y => y.ServiceName == x.ServiceName)!.ServiceDisplayName;
                            x.TimeStamp = mappeddata.FirstOrDefault(y => y.ServiceName == x.ServiceName)!.TimeStamp;
                            x.ServiceStatus = mappeddata.FirstOrDefault(y => y.ServiceName == x.ServiceName)!.ServiceStatus;


                        }
                    });
                    _uow.windowservices.UpdateRange(dbdata.ToList());

                }
                else
                {
                    _uow.windowservices.AddRange(mappeddata);
                }
                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<WindowServicesDto>>(mappeddata);
                response.Status = "Success";
                response.Message = "Data Saved";
                response.Data = retdata;
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;

            }
            return response;

        }
        public async Task<Response> GetWindowServicesInformationById(string userid)
        {
            Response response = new Response();
            try
            {
                var data = _uow.windowservices.GetAll(x => x.SystemId == userid);
                var mapdata = _mapper.Map<List<WindowServicesDto>>(data);

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

        public async Task<Response> GetWindowServicesInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.windowservices.GetAllAsync();
                var mapdata = _mapper.Map<List<WindowServicesDto>>(data);

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

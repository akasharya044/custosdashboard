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
    public class PortDetails : IPortInformation
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public PortDetails(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response> AddPortInformation(List<PortInformationDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<PortInformation>>(data);
                var dbdata = await _uow.portinformation.GetAllAsync(x => x.SystemId == data.FirstOrDefault().SystemId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    dbdata.ToList().ForEach(x =>
                    {
                        var data = mappeddata.Find(y => y.ProcessId == x.ProcessId) != null ? mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.ProcessId.ToString() : "";

                        if (data != "")
                        {
                            x.LocalPort = mappeddata.Find(y => y.ProcessId! == x.ProcessId!)!.LocalPort;
                            x.LocalEndpoint = mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.LocalEndpoint;
                            x.Service = mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.Service;
                            x.TimeStamp = mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.TimeStamp;
                            x.State = mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.State;
                            x.RemotePort = mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.RemotePort;
                            x.RemoteEndpint = mappeddata.FirstOrDefault(y => y.ProcessId == x.ProcessId)!.RemoteEndpint;

                        }
                    });
                    _uow.portinformation.UpdateRange(dbdata.ToList());

                    //var itemsNotInDb = dbdata.Where(dbItem => !mappeddata.Any(mappedItem => mappedItem.Id == dbItem.Id));

                    //var itemsInDbNotInMappedData = dbdata.Where(dbItem => !dbdata.Any(mappedItem => mappedItem.Id == dbItem.Id));

                    //foreach (var item in itemsNotInDb)
                    //{
                    //    //item.IsActive = false;
                    //    //item.UnInstalled = DateTime.Now;
                    //    _uow.portinformation.Update(item);
                    //}

                    //foreach (var item in itemsInDbNotInMappedData)
                    //{
                    //    //item.InstalledOn = DateTime.Now;
                    //    _uow.portinformation.Add(item);
                    //}

                }
                else
                {
                    _uow.portinformation.AddRange(mappeddata);
                }
                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<PortInformationDto>>(mappeddata);
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
        public async Task<Response> GetPortInformationById(string userid)
        {
            Response response = new Response();
            try
            {
                var data = _uow.portinformation.GetAll(x => x.SystemId == userid);
                var mapdata = _mapper.Map<List<PortInformationDto>>(data);

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

        public async Task<Response> GetPortInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.portinformation.GetAllAsync();
                var mapdata = _mapper.Map<List<PortInformationDto>>(data);

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

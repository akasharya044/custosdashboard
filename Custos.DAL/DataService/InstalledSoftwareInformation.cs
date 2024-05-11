using AutoMapper;
using Custos.DAL.Unitofworks;
using custos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models.DTO;

namespace custos.DAL.DataService
{
    public class InstalledSoftwareInformation : IInstalledSoftware
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public InstalledSoftwareInformation(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response> AddInstalledSoftwareInformation(List<InstalledSoftwareDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<InstalledSoftware>>(data);
                var dbdata = await _uow.installedsoftware.GetAllAsync(x => x.SystemId == data.FirstOrDefault().SystemId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    dbdata.ToList().ForEach(x =>
                    {
                        var data = mappeddata.Find(y => y.DisplayName == x.DisplayName) != null ? mappeddata.FirstOrDefault(y => y.DisplayName == x.DisplayName)!.DisplayName : "";

                        if (data != "")
                        {
                            x.Publisher = mappeddata.Find(y => y.DisplayName! == x.DisplayName!)!.Publisher;
                            x.Size = mappeddata.FirstOrDefault(y => y.DisplayName == x.DisplayName)!.Size;
                            x.TimeStamp = mappeddata.FirstOrDefault(y => y.DisplayName == x.DisplayName)!.TimeStamp;
                            x.InstalledOn = mappeddata.FirstOrDefault(y => y.DisplayName == x.DisplayName)!.InstalledOn;
                            x.Version = mappeddata.FirstOrDefault(y => y.DisplayName == x.DisplayName)!.Version;


                        }
                    });
                    _uow.installedsoftware.UpdateRange(dbdata.ToList());


                }
                else
                {
                    _uow.installedsoftware.AddRange(mappeddata);
                }
                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<InstalledSoftwareDto>>(mappeddata);
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

        public async Task<Response> GetInstalledSoftwareInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.installedsoftware.GetAllAsync();
                var mapdata = _mapper.Map<List<InstalledSoftwareDto>>(data);

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
        public async Task<Response> GetInstalledSoftwareInformationById(string userid)
        {
            Response response = new Response();
            try
            {
                var data = _uow.installedsoftware.GetAll(x => x.SystemId == userid);
                var mapdata = _mapper.Map<List<InstalledSoftwareDto>>(data);

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

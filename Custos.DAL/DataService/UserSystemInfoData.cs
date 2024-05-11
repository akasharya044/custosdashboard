using AutoMapper;
using custos.Models;
using custos.Models.DTO;
using Custos.DAL.Unitofworks;

namespace Custos.DAL.DataService
{
    public class UserSystemSoftwareData : IUserSystemSoftwareData
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public UserSystemSoftwareData(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response> AddUserSystemSoftware(List<SoftwareInformationDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<SoftwareInformation>>(data);
                var dbdata = await _uow.UserSystemSoftware.GetAllAsync(x => x.SystemId == data.FirstOrDefault().SystemId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    dbdata.ToList().ForEach(x =>
                    {
                        var data = mappeddata.Find(y => y.ProcessName == x.ProcessName) != null ? mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.ProcessName : "";

                        if (data != "")
                        {
                            x.Starttime = mappeddata.Find(y => y.ProcessName! == x.ProcessName!)!.Starttime;
                            x.CpuUsage = mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.CpuUsage;
                            x.TimeStamp = mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.TimeStamp;
                            x.ModuleName = mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.ModuleName;
                            x.WindowTitle = mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.WindowTitle;
                            x.MemorySize = mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.MemorySize;
                            x.Pid = mappeddata.FirstOrDefault(y => y.ProcessName == x.ProcessName)!.Pid;

                        }
                    });
                    _uow.UserSystemSoftware.UpdateRange(dbdata.ToList());

                }
                else
                {
                    _uow.UserSystemSoftware.AddRange(mappeddata);
                }
                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<SoftwareInformationDto>>(mappeddata);
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

        public async Task<Response> GetAllSystemSoftware()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.UserSystemSoftware.GetAllAsync();
                var mapdata = _mapper.Map<List<SoftwareInformationDto>>(data);

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
        public async Task<Response> AddUserSystemHardware(List<HardwareInformationDto> data)
        {
            Response response = new Response();
            try
            {
                List<HardwareInformation> hardinfo = new List<HardwareInformation>();
                var mappeddata = _mapper.Map<List<HardwareInformation>>(data);

                var dbdata = await _uow.UserSystemHardware.GetAllAsync(x => x.SystemId == data.FirstOrDefault().SystemId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    dbdata.ToList().ForEach(x =>
                    {
                        var data = mappeddata.Find(y => y.Name == x.Name) != null ? mappeddata.FirstOrDefault(y => y.Name == x.Name)!.Name : "";

                        if (data != "")
                        {
                            x.Qualifires = mappeddata.Find(y => y.Name! == x.Name!)!.Qualifires;
                            x.Origin = mappeddata.FirstOrDefault(y => y.Name == x.Name)!.Origin;
                            x.TimeStamp = mappeddata.FirstOrDefault(y => y.Name == x.Name)!.TimeStamp;
                            x.IsLocal = mappeddata.FirstOrDefault(y => y.Name == x.Name)!.IsLocal;
                            x.Value = mappeddata.FirstOrDefault(y => y.Name == x.Name)!.Value;
                            x.IsArray = mappeddata.FirstOrDefault(y => y.Name == x.Name)!.IsArray;
                            x.Type = mappeddata.FirstOrDefault(y => y.Name == x.Name)!.Type;

                        }
                    });
                    _uow.UserSystemHardware.UpdateRange(dbdata.ToList());





                }

                else
                {
                    _uow.UserSystemHardware.AddRange(mappeddata);
                }

                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<HardwareInformationDto>>(mappeddata);
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
        public async Task<Response> GetAllSystemHardware()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.UserSystemHardware.GetAllAsync();
                var mapdata = _mapper.Map<List<HardwareInformationDto>>(data);

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

        public async Task<Response> GetHardwareByUserid(string user)
        {
            Response response = new Response();
            try
            {
                var data = _uow.UserSystemHardware.GetAll(x => x.SystemId == user);
                var mapdata = _mapper.Map<List<HardwareInformationDto>>(data);

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

        public async Task<Response> GetSoftwareByUserId(string user)
        {
            Response response = new Response();
            try
            {
                var data = _uow.UserSystemSoftware.GetAll(x => x.SystemId == user);
                var mapdata = _mapper.Map<List<SoftwareInformationDto>>(data);

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

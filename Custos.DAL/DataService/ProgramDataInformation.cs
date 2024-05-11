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
    public class ProgramDataInformation:IProgramData
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public ProgramDataInformation(IMapper mapper, IUnitOfWorks uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response> AddProgramDataInformation(List<ProgramDataDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<ProgramData>>(data);


                var dbdata = await _uow.programdata.GetAllAsync(x => x.UserId == data.FirstOrDefault().UserId);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.programdata.RemoveRange(dbdata);
                    _uow.programdata.AddRange(mappeddata);
                }
                else
                {
                    _uow.programdata.AddRange(mappeddata);
                }


                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<ProgramDataDto>>(mappeddata);
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

        public async Task<Response> GetProgramDataInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.programdata.GetAllAsync();
                var mapdata = _mapper.Map<List<ProgramDataDto>>(data);

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
        public async Task<Response> GetProgramDataInformationByUserId(string userid)
        {
            Response response = new Response();
            try
            {
                
                var data =  _uow.programdata.GetAll(x => x.UserId == userid);
                var mapdata = _mapper.Map<List<ProgramDataDto>>(data);

                if (mapdata != null)
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
        public async Task<Response> GetProgramDataLogInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.programdatalog.GetAllAsync();
                var mapdata = _mapper.Map<List<ProgramDataDto>>(data);

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
        public async Task<Response> GetProgramDataLogInformationByUserId(string userid)
        {
            Response response = new Response();
            try
            {

                var data = _uow.programdatalog.GetAll(x => x.UserId == userid);
                var mapdata = _mapper.Map<List<ProgramDataDto>>(data);

                if (mapdata != null)
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
        public async Task<Response> AddProgramDataLogInformation(List<ProgramDataLogDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<ProgramDataLog>>(data);


                //var dbdata = await _uow.programdata.GetAllAsync(x => x.UserId == data.FirstOrDefault().UserId);
               // if (dbdata != null && dbdata.Count() > 0)

                    _uow.programdatalog.AddRange(mappeddata);
                


                await _uow.SaveAsync();
                var retdata = _mapper.Map<List<ProgramDataLogDto>>(mappeddata);
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

    }
}


using AutoMapper;
using Custos.DAL.Unitofworks;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models;
using custos.Models.AdditionalInfo;

namespace custos.DAL.DataService
{
    public  class CommandInformation:ICommandInformation
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        public CommandInformation(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response> GetCommandInformation()
        {
            Response response = new Response();
            try
            {
                var data = await _uow.commanddata.GetAllAsync();
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
        public async Task<Response> AddCommandInformation(List<CommandDataDto> data)
        {
            Response response = new Response();
            try
            {
                var mappeddata = _mapper.Map<List<CommandData>>(data);
                var dbdata = await _uow.commanddata.GetAllAsync(x => x.commandid == mappeddata.FirstOrDefault().commandid);
                if (dbdata != null && dbdata.Count() > 0)
                {
                    _uow.commanddata.UpdateRange(mappeddata);
                    _uow.Save();
                }
                else
                {
                    _uow.commanddata.AddRange(mappeddata);
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


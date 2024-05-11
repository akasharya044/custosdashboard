using custos.Models;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public interface IProgramData

    { 
            Task<Response> GetProgramDataInformation();
            Task<Response> AddProgramDataInformation(List<ProgramDataDto> data);
        Task<Response> GetProgramDataInformationByUserId(string userid);
        Task<Response> AddProgramDataLogInformation(List<ProgramDataLogDto> data);
        Task<Response> GetProgramDataLogInformation();
        Task<Response> GetProgramDataLogInformationByUserId(string userId);



    }
}

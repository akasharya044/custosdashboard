using custos.Models;
using custos.Models.AdditionalInfo;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
   public interface ICommandInformation
    {
        Task<Response> GetCommandInformation();
        Task<Response> AddCommandInformation(List<CommandDataDto> data);
    }
}

using custos.Models;
using custos.Models.AdditionalInfo;
using custos.Models.SystemInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public interface IRegisterdevice
    {
        Task<Response> GetRegisterdeviceInformation();
        Task<Response> AddRegisterdeviceInformation(RegisterDeviceDto data);
        Task<Response> GetRegisterdeviceInformationById(string userid);
    }
}


using custos.Models;
using custos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public interface IDeviceDetailsInformation
    {
        Task<Response> GetDeviceInformation();
        Task<Response> AddDeviceInformation(DeviceDetailsDTO data);
    }
}

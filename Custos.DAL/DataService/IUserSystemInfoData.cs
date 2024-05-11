

using custos.Models;
using custos.Models.DTO;

namespace Custos.DAL.DataService
{
	public interface IUserSystemSoftwareData 
    {
        Task<Response> AddUserSystemSoftware(List<SoftwareInformationDto> data);

        Task<Response> GetAllSystemSoftware();

        Task<Response> AddUserSystemHardware(List<HardwareInformationDto> data);

        Task<Response> GetAllSystemHardware();

        Task<Response> GetHardwareByUserid(string user);

        Task<Response> GetSoftwareByUserId(string user);


    }
}

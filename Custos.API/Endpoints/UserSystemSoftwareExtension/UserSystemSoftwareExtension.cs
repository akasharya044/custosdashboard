using custos.Models;
using custos.Models.DTO;
using Custos.DAL.DataService;
using System.Runtime.InteropServices;

namespace Custos.API.Endpoints
{
	public static partial class UserSystemSoftwareExtension
    {
        public static async Task<IResult> UserSystemSoftware(IDataService service, List<SoftwareInformationDto> dtos)
        {
            var data = await service.userSystemSoftwareData.AddUserSystemSoftware(dtos);
            return Results.Ok(data);
        }

        public static async Task<IResult> GetUserSystemSoftware(IDataService service)
        {
            var data = await service.userSystemSoftwareData.GetAllSystemSoftware();
            return Results.Ok(data);
        }
        public static async Task<IResult> AddSystemHardware(IDataService service, List<HardwareInformationDto> dtos)
        {
            var data = await service.userSystemSoftwareData.AddUserSystemHardware(dtos);
            return Results.Ok(data);

        }
        public static async Task<IResult> GetallHardware(IDataService service)
        {
            var data = await service.userSystemSoftwareData.GetAllSystemHardware();
            return Results.Ok(data);    
        }

        public static async Task<IResult> GetHardwareByUserId(IDataService service , string user)
        {
            var data = await service.userSystemSoftwareData.GetHardwareByUserid(user);
            return Results.Ok(data);
        }

        public static async Task<IResult> GetSoftwareByUserId(IDataService service , string user)
        {
            var data = await service.userSystemSoftwareData.GetSoftwareByUserId(user);
            return Results.Ok(data);
        }

    }
}

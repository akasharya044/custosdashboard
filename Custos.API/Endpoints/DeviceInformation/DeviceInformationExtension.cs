using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class DeviceInformationExtension
    {
        public static async Task<IResult> AddDeviceInformation(DeviceDetailsDTO data, IDataService dataService)
        {
            var response = await dataService.deviceDetailsInformation.AddDeviceInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetDeviceInformation(IDataService dataService)
        {
            var response = await dataService.deviceDetailsInformation.GetDeviceInformation();
            return Results.Ok(response);
        }
    }
}

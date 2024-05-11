using Custos.DAL.DataService;
using custos.Models.DTO;

namespace custos.API.Endpoints
{
    public static partial class WindowServiceExtension

    {
        public static async Task<IResult> AddWindowServicesInformation(List<WindowServicesDto> data, IDataService dataService)
        {
            var response = await dataService.windowServices.AddWindowServicesInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetWindowServicesInformation(IDataService dataService)
        {
            var response = await dataService.windowServices.GetWindowServicesInformation();
            return Results.Ok(response);
        }
        public static async Task<IResult> GetWindowServicesInformationById(IDataService dataService, string userid)
        {
            var response = await dataService.windowServices.GetWindowServicesInformationById(userid);
            return Results.Ok(response);
        }
    }
}

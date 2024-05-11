using Custos.DAL.DataService;
using custos.Models.DTO;

namespace custos.API.Endpoints
{
    public static partial class PortInformationExtension
    {
        public static async Task<IResult> AddPortInformation(List<PortInformationDto> data, IDataService dataService)
        {
            var response = await dataService.portInformation.AddPortInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetPortInformation(IDataService dataService)
        {
            var response = await dataService.portInformation.GetPortInformation();
            return Results.Ok(response);
        }
        public static async Task<IResult> GetPortById(IDataService dataService, string userid)
        {
            var response = await dataService.portInformation.GetPortInformationById(userid);
            return Results.Ok(response);
        }
    }
}

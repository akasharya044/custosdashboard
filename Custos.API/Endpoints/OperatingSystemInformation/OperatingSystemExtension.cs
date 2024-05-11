using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class OperatingSystemExtension
    {
        public static async Task<IResult> AddOperatingSystemInformation(OperatindSystemDto data, IDataService dataService)
        {
            var response = await dataService.operatingSystem.AddOperatingSystemInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetOperatingSystemInformation(IDataService dataService)
        {
            var response = await dataService.operatingSystem.GetOperatingSystemInformation();
            return Results.Ok(response);
        }
    }
}

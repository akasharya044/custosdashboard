using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class OSCoreExtension
    {
        public static async Task<IResult> AddOSCoreInformation(OSCoreDto data, IDataService dataService)
        {
            var response = await dataService.osCoreInformation.AddOSCoreInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetOSCoreInformation(IDataService dataService)
        {
            var response = await dataService.osCoreInformation.GetOSCoreInformation();
            return Results.Ok(response);
        }
    }
}

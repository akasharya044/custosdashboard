using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class BackgroundThresholdExtension
    {
        public static async Task<IResult> AddBackgroundThresholdInformation(BackgroundThresholdDto data, IDataService dataService)
        {
            var response = await dataService.BackgroundThreshold.AddBackgroundThresholdInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetBackgroundThresholdInformation(IDataService dataService)
        {
            var response = await dataService.BackgroundThreshold.GetBackgroundThresholdInformation();
            return Results.Ok(response);
        }
    }
}

using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class HarddiskExtension
    {
        public static async Task<IResult> AddHarddiskInformation(HarddiskDetailsDto data, IDataService dataService)
        {
            var response = await dataService.harddiskInformation.AddHarddiskInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetHarddiskInformation(IDataService dataService)
        {
            var response = await dataService.harddiskInformation.GetHarddiskInformation();
            return Results.Ok(response);
        }
    }
}


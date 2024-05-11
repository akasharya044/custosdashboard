using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class AntivirusInformationExtension
    {
        public static async Task<IResult> AddAntivirusInformation(AntivirusDetailsDto data, IDataService dataService)
        {
            var response = await dataService.antivirusInformation.AddAntivirusInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetAntivirusInformation(IDataService dataService)
        {
            var response = await dataService.antivirusInformation.GetAntivirusInformation();
            return Results.Ok(response);
        }
    }
}

using custos.Models.DTO;
using Custos.DAL.DataService;

namespace custos.API.Endpoints
{
    public static partial class InstalledSoftwareExtension
    {
        public static async Task<IResult> AddInstalledSoftwareInformation(List<InstalledSoftwareDto> data, IDataService dataService)
        {
            var response = await dataService.installedSoftware.AddInstalledSoftwareInformation(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetInstalledSoftwareInformation(IDataService dataService)
        {
            var response = await dataService.installedSoftware.GetInstalledSoftwareInformation();
            return Results.Ok(response);
        }
        public static async Task<IResult> GetInstalledSoftwareInformationById(IDataService dataService, string userid)
        {
            var response = await dataService.installedSoftware.GetInstalledSoftwareInformationById(userid);
            return Results.Ok(response);
        }
    }
}

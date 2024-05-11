using custos.Models;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class AreaExtensions
    {

        public static async Task<IResult> AddArea(List<AreaDTO> data, IDataService dataService)
        {
            //var response = await dataService.areadata.AddArea(data);
            return Results.Ok();
        }

        public static async Task<IResult> GetArea(IDataService dataService, int categoryId, int SubcategoryId)
        {
            //var response = await dataService.areadata.GetArea(categoryId,SubcategoryId);
            return Results.Ok();
        }
		public static async Task<IResult> GetAreas(IDataService dataService, int categoryId, int SubcategoryId)
		{
			var response = await dataService.areadata.GetAreas(categoryId, SubcategoryId);
			return Results.Ok(response);
		}
		public static async Task<IResult> GetAreaAll(IDataService dataService)
		{
			//var response = await dataService.areadata.GetAreaAll();
			return Results.Ok();
		}
	}
}

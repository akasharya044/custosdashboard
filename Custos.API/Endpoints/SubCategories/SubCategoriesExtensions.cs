using custos.Models;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class SubCategoriesExtensions
	{
		public static async Task<IResult> SubCategoriesList(IDataService dataService,int categoryId)
		{
			var response = await dataService.subCategoriesData.GetSubCategories(categoryId);
			return Results.Ok(response);
		}
		public static async Task<IResult> SubGetAllCategoriesList(IDataService dataService)
		{
			var response = await dataService.subCategoriesData.GetAllSubCategories();
			return Results.Ok(response);
		}
		public static async Task<IResult> AddSubCategories(List<SubCategoriesDto> data, IDataService dataService)
		{
			var response = await dataService.subCategoriesData.AddSubCategories(data);
			return Results.Ok(response);
		}
	}
}

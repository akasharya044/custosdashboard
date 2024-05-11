using custos.Models;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class CategoriesExtensions
	{
		public static async Task<IResult> CategoriesList(IDataService dataService)
		{
			var response = await dataService.categoriesData.GetCategories();
			return Results.Ok(response);
		}
		public static async Task<IResult> AddCategories(List<CategoriesDto> data, IDataService dataService)
		{
			var response = await dataService.categoriesData.AddCategories(data);
			return Results.Ok(response);
		}
	}
}

namespace Custos.API.Endpoints
{
    public static partial class SubCategoriesExtensions
	{
		public static RouteGroupBuilder MapSubCategoryEndpoint(this RouteGroupBuilder group)
		{
			group.MapGet("/{categoryId}", SubCategoriesList);
			group.MapPost("", AddSubCategories);
			group.MapGet("", SubGetAllCategoriesList);
			return group;
		}
	}
}

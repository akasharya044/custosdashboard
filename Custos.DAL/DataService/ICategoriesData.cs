using custos.Models;

namespace Custos.DAL.DataService
{
	public interface ICategoriesData
	{
		Task<Response> GetCategories();
		Task<Response> AddCategories(List<CategoriesDto> data);
	}
}

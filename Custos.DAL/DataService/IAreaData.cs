using custos.Models;

namespace Custos.DAL.DataService
{
	public interface IAreaData
    {
		//      Task<Response> AddArea(List<AreaDTO> data);
		//      Task<Response> GetArea (int categoryId,int SubcategoryId);
		//      Task<Response> GetAreas(int categoryId, int SubcategoryId);
		//Task<Response> GetAreaAll();
		Task<Response> GetAreas(int categoryid, int subcategoryid);

	}
}

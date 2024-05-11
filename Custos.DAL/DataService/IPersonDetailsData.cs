using custos.Models;
using custos.Modelss;

namespace Custos.DAL.DataService
{
	public interface IPersonDetailsData
	{
		//Task<Response> AddPersonDetails(List<PersonDetailsDto> data);
		//Task<Response> GetPersonDetails();
		//Task<Response> SearchPersonDetails(string value);

		Task<Response> GetPersonDetails();

	}
}

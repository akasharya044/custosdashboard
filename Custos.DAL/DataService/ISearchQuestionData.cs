using custos.Models;

namespace Custos.DAL.DataService
{
	public interface ISearchQuestionData
    {
        Task<Response> GetAllSearchQuestion();
    }
}

using custos.Models;

namespace Custos.DAL.DataService
{
	public interface ISubCategoriesData
	{
		Task<Response> GetSubCategories(int categoryId);
		Task<Response> GetAllSubCategories();
		Task<Response> GetQuestion();
		Task<Response> GetQuestionByKeyword(string text);
        Task<Response> GetAnswers(int questionId);
		Task<Response> AddSubCategories(List<SubCategoriesDto> data);
		Task<Response> AddQuestions(List<QuestionsDto> data);
		Task<Response> AddAnswers(List<AnswersDto> data);
		Task<Response> AddQuestionAnswer(QuestionDto data);
		Task<Response> GetQuestionAnswers();
	}
}

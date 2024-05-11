using custos.Models;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class QuestionAnswerExtensions
    {
        public static async Task<IResult> QuestionsList(IDataService dataService)
        {
            var response = await dataService.subCategoriesData.GetQuestion();
            return Results.Ok(response);
        }
        public static async Task<IResult> QuestionsByText(IDataService dataService, string text)
        {
            var response = await dataService.subCategoriesData.GetQuestionByKeyword(text);
            return Results.Ok(response);
        }
        public static async Task<IResult> AnswersList(IDataService dataService, int questionId)
        {
            var response = await dataService.subCategoriesData.GetAnswers(questionId);
            return Results.Ok(response);
        }
        public static async Task<IResult> AddQuestions(List<QuestionsDto> data, IDataService dataService)
        {
            var response = await dataService.subCategoriesData.AddQuestions(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> AddAnswers(List<AnswersDto> data, IDataService dataService)
        {
            var response = await dataService.subCategoriesData.AddAnswers(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> AddQuestionAnswer(QuestionDto data, IDataService dataService)
        {
            var response = await dataService.subCategoriesData.AddQuestionAnswer(data);
            return Results.Ok(response);
        }
        public static async Task<IResult> GetQuestionAnswerList(IDataService dataService)
        {
            var response = await dataService.subCategoriesData.GetQuestionAnswers();
            return Results.Ok(response);
        }
        public static async Task<IResult> GetAllSearchQuestionList(IDataService dataService)
        {
            var response = await dataService.searchQuestion.GetAllSearchQuestion();
            return Results.Ok(response);
        }
    }
}

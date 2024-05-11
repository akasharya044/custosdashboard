namespace Custos.API.Endpoints
{
    public static partial class QuestionAnswerExtensions
    {
        public static RouteGroupBuilder MapQuestionAnswerEndpoint(this RouteGroupBuilder group)
        {
           
            group.MapGet("/questions", QuestionsList);
            group.MapGet("/questions/text", QuestionsByText);
            group.MapPost("/questions", AddQuestions);
            group.MapGet("/{questionId}/answers", AnswersList);
            group.MapPost("/answers", AddAnswers);
            group.MapPost("/question/answer", AddQuestionAnswer);
            group.MapGet("/question/answer", GetQuestionAnswerList);
            group.MapGet("", GetAllSearchQuestionList);

            return group;
        }
    }
}

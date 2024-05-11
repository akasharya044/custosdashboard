
using System.ComponentModel.DataAnnotations;

namespace custos.Models
{
	public class Questions : BaseModel
	{
		[Key]
		public int Id { get; set; }
		public string? Question { get; set; }
		public int AreaId { get; set; }
		public StatusEnums Status { get; set; }

	}

	public class QuestionsDto
	{
		public int Id { get; set; }
		public int categoryId { get; set; }
		public int subCategoryId { get; set; }
		public string Question { get; set; }
	}
	public class QuestionDto
	{
		public int Id { get; set; }
		public long categoryId { get; set; }
		public long subCategoryId { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public string? category { get; set; }
		public string? Subcategory { get; set; }
		public string? Area { get; set; }
	}

	public class QuenstionAnswer
	{
		public int questionId { get; set; }
		public int answerId { get; set; }
		public string question { get; set; }
		public string answer { get; set; }
	}
	public class QuenstionAnswerDto
	{
		public int answerId { get; set; }
		public string answer { get; set; }

	}
}

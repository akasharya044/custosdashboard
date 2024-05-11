
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace custos.Models
{
    public class Answers : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Answer { get; set; }    
        public int QuestionId { get; set; }
		public StatusEnums Status { get; set; }

	}

	public class AnswersDto
	{
		public int Id { get; set; }
		public string Answer { get; set; }
		public int QuestionId { get; set; }
	}
}

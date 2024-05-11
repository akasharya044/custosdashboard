
using System.ComponentModel.DataAnnotations;

namespace custos.Models
{
    public class SearchQuestion
    {
        [Key]
        public int Id { get; set; }
        public string? SearchText { get; set; } = string.Empty;
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

	public class SearchQuestionDto
	{
		public int Id { get; set; }
		public string? SearchText { get; set; } = string.Empty;
		public int count { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

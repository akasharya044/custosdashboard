using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace custos.Models
{
    public class SubCategories : BaseModel
    {
        public int Id { get; set; }
		public string? Name { get; set; }
		public string? displaylabel { get; set; }
        public int CategoryId { get; set; }	
		public StatusEnums Status { get; set; }

	}

	public class SubCategoriesDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? displaylabel { get; set; }
		public int CategoryId { get; set; }
		public string? Category { get; set; }

	}
}

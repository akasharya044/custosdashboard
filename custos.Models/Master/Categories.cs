using System.ComponentModel.DataAnnotations;

namespace custos.Models
{
    public class Categories : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? displaylabel { get; set; }
        public string? entitytype { get; set; }
        public StatusEnums Status { get; set; }
        
    }

	public class CategoriesDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? displaylabel { get; set; }
		public string? entitytype { get; set; }

	}
}

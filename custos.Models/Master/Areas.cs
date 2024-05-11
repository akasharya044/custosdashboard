using System.ComponentModel.DataAnnotations;
namespace custos.Models
{
	public class Areas : BaseModel
    {
        [Key]
        public int Id { get; set; }
		public int SubCategoryId {  get; set; }	
        public string? Name { get; set; }
        public string? displaylabel { get; set; }
		public int CategoryId { get; set; }
		public StatusEnums Status { get; set; }

	}

	public class AreaDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? displaylabel { get; set; }
		public string? phaseid { get; set; }
		public int priority_c { get; set; }
		public int category_c { get; set; }
		public string? Category_c_DisplayLabel { get; set; }
		public string? Subcategory_c_DisplayLabel { get; set; }
		public int subcategory_c { get; set; }
	
		public DateTime? updated_at { get; set; }
		public DateTime? created_at { get; set; }
		public CategoriesDto? category { get; set; }
		public SubCategoriesDto? subcategory { get; set; }

	}

}

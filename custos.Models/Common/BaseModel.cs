using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models
{
	public class BaseModel
	{
		public DateTime? CreatedOn { get; set; } = DateTime.Now;
		public int CreatedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }= DateTime.Now;
		public int ModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
	}

	public enum StatusEnums
	{
		Draft = 1,
		Active = 2,
		Inactive = 3
	}
}


using System.ComponentModel.DataAnnotations;

namespace custos.Models
{
	public class Events
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class AntivirusDetailsDto
    {


		public int Id { get; set; }
		public string SystemId { get; set; }
		public string AntivirusName { get; set; }
		public DateTime TimeStamp { get; set; }
	}
    public class AntivirusDetails
    {
       
       
		public int Id { get; set; }
		[Key]
		public string SystemId { get; set; }
		public string AntivirusName { get; set; }
		public DateTime TimeStamp { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models
{
    public class SystemSoftware
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string InstalledOn { get; set; }
        public string Size { get; set; }
        public string SystemId { get; set; }
        public string Version { get; set; }


    }

	public class SystemSoftwareDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Publisher { get; set; }
		public string InstalledOn { get; set; }
		public string Size { get; set; }
		public string SystemId { get; set; }

		public string Version { get; set; }

	}
}

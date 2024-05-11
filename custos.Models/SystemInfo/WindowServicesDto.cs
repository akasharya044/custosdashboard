using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class WindowServicesDto
    {
        [Key]
        public string ServiceName { get; set; }
        public string? ServiceDisplayName { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? Startup { get; set; }

        public string? SystemId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
    public class WindowServices
    {
        [Key]
        public string ServiceName { get; set; }
        public string? ServiceDisplayName { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? Startup { get; set; }
        public DateTime? TimeStamp { get; set; }

        public string? SystemId { get; set; }
    }
}

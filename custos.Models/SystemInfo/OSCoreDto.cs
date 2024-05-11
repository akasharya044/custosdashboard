using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class OSCoreDto
    {
        public string? WindowActivationStatus { get; set; }
        [Key]
        public string WindowProductKey { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? SystemId { get; set; }
    }
    public class OSCore
    {
        public string? WindowActivationStatus { get; set; }
        [Key]
        public string WindowProductKey { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? SystemId { get; set; }
    }
}

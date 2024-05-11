using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class BackgroundThresholdDto
    {
        public int Id { get; set; }
       
        public double? CPUUsage { get; set; }
        public double? MemoryUsage { get; set; }
        public long? NetworkUsage { get; set; }
    }
    public class BackgroundThreshold
    {
        [Key]
        public int Id { get; set; }
        public double? CPUUsage { get; set; }
        public double? MemoryUsage { get; set; }
        public long? NetworkUsage { get; set; }

    }
}

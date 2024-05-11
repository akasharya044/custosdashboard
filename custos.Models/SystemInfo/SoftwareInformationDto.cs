using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class SoftwareInformationDto
    {
        public int Id { get; set; }
        public string? WindowTitle { get; set; }

        public string? ProcessName { get; set; }

        public string? SystemId { get; set; }

        public string? MemorySize { get; set; }

        public string? ModuleName { get; set; }

        public string? Starttime { get; set; }
        public string? Pid { get; set; }

        public string? CpuUsage { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
    public class SoftwareInformation
    {
        [Key]
        public int Id { get; set; }
        public string? WindowTitle { get; set; }

        public string? ProcessName { get; set; }

        public string? SystemId { get; set; }

        public string? MemorySize { get; set; }

        public string? ModuleName { get; set; }

        public string? Starttime { get; set; }
        public string? Pid { get; set; }

        public string? CpuUsage { get; set; }
        public DateTime? TimeStamp { get; set; }

    }
}

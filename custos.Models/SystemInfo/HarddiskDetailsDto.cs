using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class HarddiskDetailsDto
    {
        public string DriveName { get; set; }
        public string? DriveType { get; set; }
        public string? DriveFormat { get; set; }
        public string? SerialNumber { get; set; }
        public string? TotalSize { get; set; }
        public string? FreeSpace { get; set; }
        public string? AvailableFreeSpace { get; set; }
        public string? NonSystemDriveName { get; set; }
        public string? NonSystemTotalSpace { get; set; }
        public string? NonSystemFreeSpace { get; set; }
        public string SystemId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
    public class HarddiskDetails
    {
        public string? DriveName { get; set; }
        public string? DriveType { get; set; }
        public string? DriveFormat { get; set; }
        public string? SerialNumber { get; set; }
        public string? TotalSize { get; set; }
        public string? FreeSpace { get; set; }
        public string? AvailableFreeSpace { get; set; }
        public string? NonSystemDriveName { get; set; }
        public string? NonSystemTotalSpace { get; set; }
        public string? NonSystemFreeSpace { get; set; }
        [Key]
        public string SystemId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}

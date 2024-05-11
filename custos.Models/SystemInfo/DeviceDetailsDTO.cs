using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class DeviceDetailsDTO
    {
        public string? DeviceVersion { get; set; }
        public string? DeviceName { get; set; }

        public string BIOS { get; set; }

        public string? MACAddress { get; set; }

        public string? IPAddress { get; set; }
        public string? VirtualMemory { get; set; }
        public string? AvailableVirtualMemory { get; set; }

        public string? DisplayManufacturer { get; set; }

        public string? TotalPhysicalMemory { get; set; }
        public string? TotalAvailablePhysicalMemory { get; set; }

        public string? DisplayDetails { get; set; }

        public string? DisplayName { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? SystemId { get; set; }


    }
    public class DeviceDetails
    {
        public string? DeviceVersion { get; set; }
        public string? DeviceName { get; set; }
        [Key]

        public string BIOS { get; set; }

        public string? MACAddress { get; set; }

        public string? IPAddress { get; set; }
        public string? VirtualMemory { get; set; }
        public string? AvailableVirtualMemory { get; set; }

        public string? TotalPhysicalMemory { get; set; }
        public string? TotalAvailablePhysicalMemory { get; set; }

        public string? DisplayManufacturer { get; set; }

        public string? DisplayDetails { get; set; }

        public string? DisplayName { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? SystemId { get; set; }

    }
}

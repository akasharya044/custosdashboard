using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class ProgramDataDto
    {
        [JsonPropertyName("programNames")]
        public string? ProgramNames { get; set; }
        [JsonPropertyName("pids")]
        public string? PIDs { get; set; }
        [JsonPropertyName("memoryUsages")]
        public long? MemoryUsages { get; set; }

        public double? NetworkSpeeds { get; set; }

        public double? CPUUsgaess { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }


    }
    public class ProgramDataLogDto
    {
        [JsonPropertyName("programNames")]
        public string? ProgramNames { get; set; }
        [JsonPropertyName("pids")]
        public string? PIDs { get; set; }
        [JsonPropertyName("memoryUsages")]
        public long? MemoryUsages { get; set; }

        public double? NetworkSpeeds { get; set; }

        public double? CPUUsgaess { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }


    }
    public class ProgramData
    {
        [JsonPropertyName("programNames")]
        public string? ProgramNames { get; set; }
        [JsonPropertyName("pids")]
        public string? PIDs { get; set; }
        [JsonPropertyName("memoryUsages")]
        public long? MemoryUsages { get; set; }

        public double? NetworkSpeeds { get; set; }

        public double? CPUUsgaess { get; set; }


        public string UserId { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }


    }
    public class ProgramDataLog
    {
        [JsonPropertyName("programNames")]
        public string? ProgramNames { get; set; }
        [JsonPropertyName("pids")]
        public string? PIDs { get; set; }
        [JsonPropertyName("memoryUsages")]
        public long? MemoryUsages { get; set; }

        public double? NetworkSpeeds { get; set; }

        public double? CPUUsgaess { get; set; }


        public string UserId { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime? TimeStamp { get; set; }


    }


}


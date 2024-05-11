﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class Backgroundservice
    {

        [Key]
        public string UserId { get; set; }
        public double? MemoryUsages { get; set; }
        public double? CpuUsgaes { get; set; }

        public double? NetworkUsgaes { get; set; }

        public string? CPU_Alert { get; set; }

        public DateTime? CPU_TimeStamp { get; set; }

        public string? Memory_Alert { get; set; }

        public DateTime? Memory_TimeStamp { get; set; }

        public string? Network_Alert { get; set; }

        public DateTime? Network_TimeStamp { get; set; }

    }

    public class BackgroundserviceDTO
    {
        public string UserId { get; set; }
        public double? MemoryUsages { get; set; }
        public double? CpuUsgaes { get; set; }

        public double? NetworkUsgaes { get; set; }

        public string? CPU_Alert { get; set; }

        public DateTime? CPU_TimeStamp { get; set; }

        public string? Memory_Alert { get; set; }

        public DateTime? Memory_TimeStamp { get; set; }

        public string? Network_Alert { get; set; }

        public DateTime? Network_TimeStamp { get; set; }
    }
    public static class NotyCount
        {
        public static int Count { get; set; } = 5;
        }
}

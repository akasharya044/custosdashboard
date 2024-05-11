﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.DTO
{
    public class OperatindSystemDto
    {
        public string? OS_Name { get; set; }
        public string? OS_Version { get; set; }
        public string? OS_Architecture { get; set; }
        public string? Build_Number { get; set; }
        public string? Manufacturer { get; set; }
        public string? LastBootUpTime { get; set; }
        public string? NoOfDaysLastSystemBoot { get; set; }

        public string SerialNumber { get; set; }
        public string? MembershipType { get; set; }
        public string? LastLogged { get; set; }
        public string? LastLoggedUserRole { get; set; }
        public string? CurrentUser { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? SystemId { get; set; }
    }
    public class OperatingSystem1
    {
        public string? OS_Name { get; set; }
        public string? OS_Version { get; set; }
        public string? OS_Architecture { get; set; }
        public string? Build_Number { get; set; }
        public string? Manufacturer { get; set; }
        public string? LastBootUpTime { get; set; }
        public string? NoOfDaysLastSystemBoot { get; set; }
        [Key]
        public string SerialNumber { get; set; }
        public string? MembershipType { get; set; }
        public string? LastLogged { get; set; }
        public string? LastLoggedUserRole { get; set; }
        public string? CurrentUser { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? SystemId { get; set; }
    }
}



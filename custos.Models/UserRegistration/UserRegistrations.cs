using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.UserRegistration
{
    public class UserRegistrations
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? SystemId { get; set; } 
        public DateTime RegistrationDateTime { get; set; }
        public string? MacAddress { get; set; }  
        public string? UniqueKey { get; set; }
        public string? DeviceType { get; set; }  
        public string? Location { get; set; }
        public string? AgentVersion { get; set; }
        public string? UserName { get; set; }
        public string? DisplayLabel { get; set; }
        public string? IpAddress { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsDelete { get; set; }

    }
    public class UserRegistrationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? UserName { get; set; }
        public string? SystemId { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string? MacAddress { get; set; }
        public string? UniqueKey { get; set; }
        public string? DeviceType { get; set; }
        public string? Location { get; set; }
        public string? AgentVersion { get; set; }
        public string? DisplayLabel { get; set; }
        public string? IpAddress { get; set; }
        public bool IsRegistered { get; set; }


    }

    
}

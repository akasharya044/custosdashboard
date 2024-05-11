using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.SystemInfo
{
    public class RegisterDevice
    {
        [Key]
        public string systemid { get; set; }
        public string? UniqueKey {  get; set; }
        public string? entity_type { get; set; }
        public bool? IsDeleted { get; set; }
        public string? SubType { get; set; }
        public long? LastUpdateTime { get; set; }
        public string? DisplayLabel { get; set; }
        public string? IpAddress { get; set; }
        public string? MacAddress { get; set; }
        public string? AgentVersion { get; set; }
        public string? Mobile_Number { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email_Id { get; set; }

        public string? Location { get; set; }

    }
    public class RegisterDeviceDto
    {
        
        public string systemid { get; set; }
        public string? UniqueKey { get; set; }

        public string? entity_type { get; set; }
        public bool? IsDeleted { get; set; }
        public string? SubType { get; set; }
        public long? LastUpdateTime { get; set; }
        public string? DisplayLabel { get; set; }
        public string? IpAddress { get; set; }
        public string? MacAddress { get; set; }
        public string? AgentVersion { get; set; }
        public string? Mobile_Number{  get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email_Id { get; set; }

        public string? Location { get; set; }

        public string? Status { get; set; }

       


    }
    
   
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.RbacModel
{
    public class Client : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int NoKey { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string Country { get; set; } 
		public int Pincode { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
    }

    public class ClientDTO : BaseModel
    {
		public int Id { get; set; }
		public int NoKey { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address1 { get; set; }
		public string? Address2 { get; set; }
		public string City { get; set; }
		public int State { get; set; }
        public string StateName { get; set; }
        public string Country { get; set; } = "India";
		public int Pincode { get; set; }
		public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public string fullAdd => Address1 + " " + Address2;
	}

    public class AgentRegistrationDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string ContactNo { get; set; }

        public string SystemId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string UniqueKey { get; set; }

        public string UserType { get; set; } = "Client User";

        public string Location { get; set; }
    }
}

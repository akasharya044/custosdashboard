using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace custos.Models.RbacModel
{
    public class ClientLicense : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; } = "ABCD";
        public DateTime ActivatedOn { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }
    }
	public class ClientLicenseDTO
	{

		public int Id { get; set; }
		public int ClientId { get; set; }
		public int UserId { get; set; }
		public string Key { get; set; }
		public DateTime ActivatedOn { get; set; }
		public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Active => IsActive == true ? "Yes" : "No";
	}

}

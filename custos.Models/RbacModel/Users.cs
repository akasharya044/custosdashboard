using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.RbacModel
{
    public class Users : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Addresses { get; set; }
        public bool IsActive { get; set; }

        public string Systemid { get; set; }
    }

    public class UsersDTO : BaseModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Addresses { get; set; }
        public bool IsActive { get; set; }
        public string? Token { get; set; }

        public string Systemid { get; set; }
    }

    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationKey
    {
        public string Encryptkey { get; set; }
    }
}

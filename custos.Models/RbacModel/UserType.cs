using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.RbacModel
{
    public class UserType : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }

    public class UserTypeDTO : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custos.Models.Master;

namespace custos.Models.RbacModel
{
    public class UsersRights : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Menu Menu { get; set; }
        public string Rights { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

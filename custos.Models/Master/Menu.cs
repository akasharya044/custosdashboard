using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.Master
{
    public class Menu : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ParentMenuId { get; set; }
        public int UserTypeId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
       
    }

    public class MenuDTO : BaseModel
    {
        public int Id { get; set; }
        public int ParentMenuId { get; set; }
        public int UserTypeId { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
     
    }
}

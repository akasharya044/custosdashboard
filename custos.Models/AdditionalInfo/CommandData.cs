using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.AdditionalInfo
{
    public class CommandData
    {
        [Key]
        public int Id { get; set; }
        public string? commandid { get; set; }
        public string? commandname { get; set;}
        public string? commandargument { get; set;}
    }
    public class CommandDataDto
    {
        public int Id { get; set; }
        public string? commandid { get; set; }
        public string? commandname { get; set; }
        public string? commandargument { get; set; }
    }
}

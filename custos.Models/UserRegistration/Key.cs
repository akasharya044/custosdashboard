using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models.UserRegistration
{
    public class Key
    {


        public int id {  get; set; }
        public string? key { get; set; }
        public bool status { get; set; }


    }

    public class KeyDTO
    {


        public int id { get; set; }
        public string? key { get; set; }
        public bool status { get; set; }


    }
}

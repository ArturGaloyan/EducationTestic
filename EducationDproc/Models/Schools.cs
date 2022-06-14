using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class Schools
    {
       [Key]

        public int id { get; set; }
        public string license_key { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string  address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string zipCode { get; set; }
    }
}

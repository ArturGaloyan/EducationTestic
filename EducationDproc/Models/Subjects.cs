using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class Subjects
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int schoolID { get; set; }

        public Schools school { get; set; }
    }
}

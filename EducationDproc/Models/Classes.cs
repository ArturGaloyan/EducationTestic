using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class Classes
    {
        [Key]

        public int id { get; set; }
        public string classNumber { get; set; }
        public string classGroup { get; set; }

        public int schoolID { get; set; }
        public int teacherID { get; set; }

        public Schools school { get; set; }
        public Teacher teacher { get; set; }

    }
}

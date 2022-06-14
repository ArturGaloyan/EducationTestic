using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class Testing
    {
        [Key]
        public int id { get; set; }
        public DateTime testingDate { get; set; }
        public string description { get; set; }
        public string password { get; set; }
        public string classGroup { get; set; }

        public int testEduID { get; set; }
        public int teacherID { get; set; }
        public int schoolID { get; set; }

        public TestEdu testEdu { get; set; }
        public Teacher teacher { get; set; }
        public Schools school { get; set; }
    }
}

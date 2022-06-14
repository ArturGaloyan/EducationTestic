using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class TestEdu
    {
        [Key]
        public int id { get; set; }
        public string classNumber { get; set; }
        public string paragraph { get; set; }
        public string password { get; set; }
        public int isEduStarted { get; set; }

        public int subjectID { get; set; }
        public int teacherID { get; set; }
        public int schoolID { get; set; }

        public Subjects subject { get; set; }
        public Teacher teacher { get; set; }
        public Schools school { get; set; }


    }
}

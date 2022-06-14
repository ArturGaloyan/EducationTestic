using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class ClassNumberSubjects
    {
        [Key]

        public int id { get; set; }
        public string classNumber { get; set; }
        public int subjectID { get; set; }
        public int schoolID { get; set; }

        public Subjects subject { get; set; }
        public Schools school { get; set; }
    }
}

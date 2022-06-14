using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class ClassSubjectsTeachers
    {
        [Key]
        public int id { get; set; }
        public int  classesID { get; set; }
        public int subjectID { get; set; }
        public int teacherID { get; set; }
        public int schoolID { get; set; }

        public Classes classes { get; set; }
        public Subjects subject { get; set; }
        public Teacher teacher { get; set; }
        public Schools school { get; set; }
    }
}

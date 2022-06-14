using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class TestingResults
    {
        [Key]
        public int id { get; set; }
        public DateTime testingDate { get; set; }
        public string description { get; set; }
        public string classNumber { get; set; }
        public string classGroup { get; set; }
        public string paragraph { get; set; }

        public int isTrueCount { get; set; }
        public int isFalseCount { get; set; }
        public int isNoneCount { get; set; }
        public int resultPoint { get; set; }
        public int maxPoint { get; set; }

        public int subjectID { get; set; }
        public int testEduID { get; set; }
        public int testingID { get; set; }
        public int studentID { get; set; }
        public int teacherID { get; set; }
        public int schoolID { get; set; }

        public Subjects subject { get; set; }
        public TestEdu testEdu { get; set; }
        public Testing testing { get; set; }
        public Student student { get; set; }
        public Teacher teacher { get; set; }
        public Schools school { get; set; }
    }
}

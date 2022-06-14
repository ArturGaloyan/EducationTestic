using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationDproc.Models
{
    public class EduContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }     
        public DbSet<TestEdu> TestEdus { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerStudent> AnswerStudents { get; set; }
        //public DbSet<License> Licenses { get; set; }
        public DbSet<Testing> Testings { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<TestingResults> TestingResults { get; set; }

        public DbSet<Schools> Schools { get; set; }
        public DbSet<ClassNumberSubjects> ClassNumberSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<ClassSubjectsTeachers> ClassSubjectsTeachers { get; set; }

        public EduContext(DbContextOptions x) : base(x)
        {

        }
    }
}

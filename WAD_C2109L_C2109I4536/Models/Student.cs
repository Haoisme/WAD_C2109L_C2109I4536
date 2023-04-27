using System;
using System.Collections.Generic;

namespace WAD_C2109L_C2109I4536.Models
{
    public partial class Student
    {
        public Student()
        {
            Exams = new HashSet<Exam>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public DateTime StudentDob { get; set; }
        public string StudentClass { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}

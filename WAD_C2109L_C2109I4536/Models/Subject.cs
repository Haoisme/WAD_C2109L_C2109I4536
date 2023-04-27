using System;
using System.Collections.Generic;

namespace WAD_C2109L_C2109I4536.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Exams = new HashSet<Exam>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}

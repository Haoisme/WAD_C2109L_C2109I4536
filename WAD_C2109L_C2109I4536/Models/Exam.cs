using System;
using System.Collections.Generic;

namespace WAD_C2109L_C2109I4536.Models
{
    public partial class Exam
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Mark { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}

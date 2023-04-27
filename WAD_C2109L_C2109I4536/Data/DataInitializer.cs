using WAD_C2109L_C2109I4536.Models;

namespace WAD_C2109L_C2109I4536.Data
{
    public class DataInitializer
    {
        public static void Initializer(DataContext context)
        {
            context.Database.EnsureCreated();
            if (context.Subjects.Any() && context.Students.Any() && context.Exams.Any())

                return;
            context.Database.EnsureCreated();
            var subjects = new Subject[]
            {
                 new Subject{SubjectName="Subject 1" },
                 new Subject{SubjectName="Subject 2" },
                 new Subject{SubjectName="Subject 3" },
                 new Subject{SubjectName="Subject 4" },
                 new Subject{SubjectName="Subject 5" },

             };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student{StudentName ="Student 1 ",StudentDob=new DateTime(2001,2,20),StudentClass="Class A"},
                new Student{StudentName ="Student 2 ",StudentDob=new DateTime(2001,3,20),StudentClass="Class B"},
                new Student{StudentName ="Student 3 ",StudentDob=new DateTime(2001,4,20),StudentClass="Class A"},
                new Student{StudentName ="Student 4 ",StudentDob=new DateTime(2001,5,20),StudentClass="Class C"},
                new Student{StudentName ="Student 5 ",StudentDob=new DateTime(2001,8,20),StudentClass="Class B"},
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            var exams = new Exam[]
            {
                new Exam{StudentId=1, SubjectId=1, Mark=5},
                new Exam{StudentId=1, SubjectId=2, Mark=8},
                new Exam{StudentId=1, SubjectId=3, Mark=5},
                new Exam{StudentId=1, SubjectId=4, Mark=9},
                new Exam{StudentId=1, SubjectId=5, Mark=3},

                new Exam{StudentId=2, SubjectId=1, Mark=5},
                new Exam{StudentId=2, SubjectId=2, Mark=8},
                new Exam{StudentId=2, SubjectId=3, Mark=5},
                new Exam{StudentId=2, SubjectId=4, Mark=9},
                new Exam{StudentId=2, SubjectId=5, Mark=3},

                new Exam{StudentId=3, SubjectId=1, Mark=5},
                new Exam{StudentId=3, SubjectId=2, Mark=8},
                new Exam{StudentId=3, SubjectId=3, Mark=5},
                new Exam{StudentId=3, SubjectId=4, Mark=9},
                new Exam{StudentId=3, SubjectId=5, Mark=3},

                new Exam{StudentId=4, SubjectId=1, Mark=5},
                new Exam{StudentId=4, SubjectId=2, Mark=8},
                new Exam{StudentId=4, SubjectId=3, Mark=5},
                new Exam{StudentId=4, SubjectId=4, Mark=9},
                new Exam{StudentId=4, SubjectId=5, Mark=3},

                new Exam{StudentId=5, SubjectId=1, Mark=5},
                new Exam{StudentId=5, SubjectId=2, Mark=8},
                new Exam{StudentId=5, SubjectId=3, Mark=5},
                new Exam{StudentId=5, SubjectId=4, Mark=9},
                new Exam{StudentId=5, SubjectId=5, Mark=3},


            };
            context.Exams.AddRange(exams);
            context.SaveChanges();

        }
    } 
}

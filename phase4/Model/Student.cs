using System.Collections.Generic;

namespace phase4.Model
{
    public class Student
    {
        public Student()
        {

        }

        public Student(StudentInfo info)
        {
            Info = info;
        }

        public StudentInfo Info { get; set; }
        public List<Grade> grades { get; set; }

    }
}
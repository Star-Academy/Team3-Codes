using System.Collections.Generic;
using System.Linq;

namespace phase4.Model
{
    public class Student
    {

        public Student(StudentInfo info)
        {
            Info = info;
            grades = new List<Grade>();
        }

        public StudentInfo Info { get; set; }
        public List<Grade> grades { get; set; }

        public float GetAverage()
        {
            return grades.Sum(x => x.Score) / grades.Capacity;
        }
        
        public override string ToString(){
            return ""+Info.FirstName+"  "+Info.LastName+"   Average: "+GetAverage();
        }

    }
}
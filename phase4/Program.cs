using System;
using phase4.Model;
using System.Linq;

namespace phase4
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();
            var grades = reader.Read<Grade>("resources\\Scores.json");
            var studentInfos = reader.Read<StudentInfo>("resources\\Students.json");
            var students = studentInfos.Select(s => new Student(s)).ToList();
            students.ForEach(s => s.grades = grades.FindAll(g => g.StudentNumber == s.Info.StudentNumber));
            students = students.OrderByDescending(s => s.GetAverage()).ToList();
            foreach( var student in students.Take(3))
                Console.WriteLine(student);
        }
    }
}

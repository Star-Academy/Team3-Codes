using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using phase4.Model;
using System.Linq;

namespace phase4
{
    class Program
    {
        private const string PathStudent = "resources\\Students.json";
        private const string PathScore = "resources\\Scores.json";
        static void Main(string[] args)
        {
            Reader<StudentInfo> infoReader = new Reader<StudentInfo>(PathStudent);
            var studentInfos = infoReader.Read();
            Reader<Grade> scoreReader = new Reader<Grade>(PathScore);
            var grades = scoreReader.Read();
            List<Student> students = studentInfos.Select(s => new Student(s)).ToList();
            students.ForEach(a => a.grades = grades.FindAll(c => c.StudentNumber == a.Info.StudentNumber));
            students = students.OrderByDescending(p => p.GetAverage()).ToList();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(students[i]);
            }
        }
    }
}

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
            var studentJson = File.ReadAllText(PathStudent);
            var studentInfos = JsonSerializer.Deserialize<List<StudentInfo>>(studentJson);
            var gradeJson = File.ReadAllText(PathScore);
            var grades = JsonSerializer.Deserialize<List<Grade>>(gradeJson);
           
            var students = studentInfos.Select(new )

            students.foreach(a => grades.FindAll(c => ))
           

        }
        public List<Grade> FindStudentGrades(List<Grade> grades , int studentNumber){
            return (grades.FindAll(a => a.StudentNumber == studentNumber));
        }
    }
    

}

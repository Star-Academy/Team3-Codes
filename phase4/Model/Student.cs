namespace phase4.Model
{
    public class Student
    {
        public Student()
        {

        }

        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
        }

        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
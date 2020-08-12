
namespace phase4.Model
{
    public class Grade
    {
        public Grade(int studentNumber, string lesson, float score)
        {
            StudentNumber = studentNumber;
            Lesson = lesson;
            Score = score;
        }

        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public float Score { get; set; }

    }
}
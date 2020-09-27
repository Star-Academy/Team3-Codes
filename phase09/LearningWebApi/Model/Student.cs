namespace Learning.Model
{
    public class Student : IPerson
    {
        public Person GetPerson()
        {
            return new Person(){
                Name = "Mahla",
                LastName = "Sharifi",
                Id = 1
            };
        }
    }
}
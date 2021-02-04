namespace School
{
    public class Student : Person
    {
        public int EduForm { get; set; }


        public Student(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }


        public override string GetInfo()
        {
            return base.GetInfo() + this.EduForm;
        }
    }
}
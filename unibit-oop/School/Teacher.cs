namespace School
{
    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }

        public int Title { get; set; }

        public override string GetInfo()
        {
            return this.Title + " " + base.GetInfo();
        }
    }
}
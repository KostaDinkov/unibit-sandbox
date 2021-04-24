
namespace GradeBook.Models
{
    public abstract class Person
    {
        public string FullName { get; set; }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
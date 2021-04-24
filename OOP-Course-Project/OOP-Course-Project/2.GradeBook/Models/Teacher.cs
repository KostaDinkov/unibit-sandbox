using System.Collections.Generic;

namespace GradeBook.Models
{
    public class Teacher : Person
    {
        public List<Course> Courses;

        public Teacher()
        {
            this.Courses = new List<Course>();
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
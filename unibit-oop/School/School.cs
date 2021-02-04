using System.Collections.Generic;

namespace School
{
    public class School
    {
        public School()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Courses = new List<Course>();
        }

        public string Name { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }
    }
}
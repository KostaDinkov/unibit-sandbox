using System.Collections.Generic;

namespace School
{
    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
        }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
    }
}
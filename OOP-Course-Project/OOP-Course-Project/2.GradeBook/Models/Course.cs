namespace GradeBook.Models
{
    public class Course
    {
        public int InstanceYear { get; set; }
        public string Name { get; set; }
        public int LectureCount { get; set; }
        public int PracticeCount { get; set; }

        public int Semester { get; set; }
        public Teacher Teacher { get; set; }
    }
}
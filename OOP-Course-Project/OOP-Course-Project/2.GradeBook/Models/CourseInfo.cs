namespace GradeBook.Models
{
    public class CourseInfo
    {
        public string Name { get; set; }
        public int LectureCount { get; set; }
        public int PracticeCount { get; set; }

        public int Semester { get; set; }
        public string TeacherName { get; set; }
        public double Grade { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is CourseInfo other)
            {
                return this.Name == other.Name &&
                       this.Grade == other.Grade &&
                       this.LectureCount == other.LectureCount &&
                       this.PracticeCount == other.PracticeCount &&
                       this.TeacherName == other.TeacherName &&
                       this.Semester == other.Semester;
            }

            return false;
        }
    }
}
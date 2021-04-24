using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Common;
using GradeBook.Exceptions;

namespace GradeBook.Models
{
    public class School
    {
        public School(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
            this.Courses = new List<Course>();
            this.Teachers = new List<Teacher>();
        }

        public List<CommandInfo> CommandInfos { get; private set; }

        public CommandValidator Validator { get; }

        public List<Course> Courses { get; }

        public List<Student> Students { get; }

        public List<Teacher> Teachers { get; }


        public string Name { get; }

        /// <summary>
        ///     Adds a student to the school
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            if (this.Students.Any(s => s.FullName == student.FullName))
                throw new EntityExistsException(Messages.StudentExistsMsg);

            this.Students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            if (this.Teachers.Any(t => t.FullName == teacher.FullName))
            {
                throw new EntityExistsException(Messages.TeacherExistsMsg);
            }
            this.Teachers.Add(teacher);
        }

        /// <summary>
        ///     Adds a course to the school
        /// </summary>
        /// <param name="course"></param>
        public void AddCourse(Course course)
        {
            if (this.Courses.Any(c => c.Name == course.Name))
                throw new EntityExistsException(Messages.CourseExistsMst);

            this.Courses.Add(course);
        }

        /// <summary>
        ///     Gets a string representation of the list of courses, added to the school
        /// </summary>
        /// <returns></returns>
        public string GetCoursesString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(Messages.ListOfAllCoursesMsg, this.Name));
            var counter = 1;

            foreach (var course in this.Courses.OrderBy(c => c.Semester).ThenBy(c => c.Name))
            {
                sb.AppendLine($"  {counter}. {course.Name}, {course.Teacher?.FullName}");
                counter++;
            }

            sb.AppendLine(string.Format(Messages.TotalCoursesMsg, this.Courses.Count));

            return sb.ToString().Trim('\r', '\n');
        }

        /// <summary>
        ///     Adds a course grade to the student
        /// </summary>
        /// <param name="name">The name of the student</param>
        /// <param name="courseName">The name of the course</param>
        /// <param name="grade">The grade (2-6)</param>
        public void AddGrade(string name, string courseName, double grade)
        {
            var student = this.Students.FirstOrDefault(s => s.FullName == name);
            var course = this.Courses.FirstOrDefault(c => c.Name == courseName);

            if (student == null) throw new NotFoundException(Messages.StudentNotFoundMsg);
            if (course == null) throw new NotFoundException(Messages.CourseNotFoundMsg);

            student.AddGrade(courseName, grade);
        }

        /// <summary>
        ///     Adds grade information for multiple courses to a student. If the student or a course do not exist, new ones will be
        ///     created.
        /// </summary>
        /// <param name="name">The full name of the student</param>
        /// <param name="courseInfos">A list of course entries, containing course information and a course grade for the student</param>
        public void AddGradesBulk(string name, List<CourseInfo> courseInfos)
        {
            var student = this.Students.FirstOrDefault(s => s.FullName == name);
            if (student == null)
            {
                student = new Student {FullName = name};
                this.AddStudent(student);
            }

            foreach (var courseInfo in courseInfos)
            {
                if (this.Courses.All(c => c.Name != courseInfo.Name))
                {
                    this.AddCourse(new Course
                    {
                        Name = courseInfo.Name,
                        Semester = courseInfo.Semester,
                        PracticeCount = courseInfo.PracticeCount,
                        LectureCount = courseInfo.LectureCount,
                        
                    });
                }

                student.AddGrade(courseInfo.Name, courseInfo.Grade);
            }
        }

        /// <summary>
        ///     Returns all grades for the student as a formatted string.
        /// </summary>
        /// <param name="name">The name of the student</param>
        public string GetGradesString(string name)
        {
            var sb = new StringBuilder();

            var student = this.Students.FirstOrDefault(s => s.FullName == name);
            if (student.CoursesGrades.Count == 0) return Messages.NoGradesMsg;

            if (student != null)
            {
                var result = student.CoursesGrades.Select(cg =>
                {
                    var course = this.Courses.FirstOrDefault(c => c.Name == cg.Key);

                    return new
                    {
                        course.Semester,
                        course.Name,
                        TeacherName = course.Teacher.FullName,
                        Grade = cg.Value
                    };
                }).OrderBy(c => c.Semester);

                sb.AppendLine(string.Format(Messages.GradesForMsg, name));

                foreach (var entry in result)
                {
                    sb.AppendLine(
                        string.Format(Messages.GradesLineMsg, entry.Semester, entry.Name, entry.TeacherName,
                            entry.Grade));
                }
            }
            else
            {
                throw new NotFoundException(Messages.StudentNotFoundMsg);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Returns the statistics for the semester for the given student.
        /// </summary>
        /// <param name="studentName">The name of the student</param>
        public string GetSemesterStats(string studentName)
        {
            var student = this.Students.FirstOrDefault(s => s.FullName == studentName);
            if (student == null) throw new NotFoundException(Messages.StudentNotFoundMsg);

            var courseCount = student.CoursesGrades.Count;

            var result = student.CoursesGrades.Join(this.Courses, kvp => kvp.Key, course => course.Name,
                (kvp, course) => new
                {
                    course.Name,
                    TotalHours = course.LectureCount + course.PracticeCount,
                    course.Semester,
                    Grade = kvp.Value
                }).GroupBy(c => c.Semester,
                (key, value) => new
                {
                    Semester = key, TotalHours = value.Sum(c => c.TotalHours),
                    AvgGrade = value.Average(c => c.Grade)
                }).OrderBy(s => s.Semester);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(Messages.SemesterStatsMsg, student.FullName, courseCount));

            var counter = 1;
            foreach (var entry in result)
            {
                sb.AppendLine(string.Format(Messages.SemesterStatsLineMs, counter, entry.Semester, entry.TotalHours,
                    entry.AvgGrade));
                counter++;
            }

            sb.AppendLine(string.Format(Messages.TotalAverageGradeMsg, student.GetAverageGrade()));

            return sb.ToString();
        }


        /// <summary>
        ///     Returns a list of all students added to the school.
        /// </summary>
        public string GetStudentsString()
        {
            return string.Join("\n", this.Students);
        }

        public string GetTeachersString()
        {
            return string.Join("\n", this.Teachers);
        }

        public void AddTeacherToCourse(string tName, string cName)
        {
            
            var course = this.Courses.FirstOrDefault(c => c.Name == cName);
            if(course == null) throw new NotFoundException(Messages.CourseNotFoundMsg);

            var teacher = this.Teachers.FirstOrDefault(t => t.FullName == tName);
            if(teacher == null) throw new NotFoundException(Messages.TeacherNotFoundMsg);

            teacher.Courses.Add(course);
            course.Teacher = teacher;
        }
    }
}
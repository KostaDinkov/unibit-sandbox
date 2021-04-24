namespace GradeBook.Common
{
    public static class Messages
    {
        public const string OOPMessage = "В този проект абстрактният клас е Person и той се наследява от Student и Теаcher, които могат да бъдат създадени от командния ред по-долу.Натиснете 'h' за листинг на всични възможни команди";
        public const string GradesAdded = "Grades added successfuly.";


        public const string WelcomeMsg = "{0} learning management system.\r\n" +
                                         "For a list of available commands type h:\r\n" +
                                         "Enter Command:";

        //add student
        public const string StudentAddedMsg = "Student {0} added to school";

        public const string CourseAddedMsg = "Course {0} added to school";

        public const string ListOfAllCoursesMsg = "List of all courses at {0}";

        public const string TotalCoursesMsg = "Total: {0} courses.";

        public const string GradeAddedMsg = "{0} grade {1} added to student {2}";

        //get-grades
        public const string GradesForMsg = "Grades for student {0}:";

        public const string GradesLineMsg =
            "Semester: {0}, Course: {1}, Teacher: {2}, Grade: {3}";

        //get-semester-stats
        public const string SemesterStatsMsg = "Student: {0}\r\n" +
                                               "Total courses: {1}\r\n" +
                                               "Semester average grades and total study hours:";

        public const string SemesterStatsLineMs = "  {0}. Semester {1}, {2}: {3:F2}";
        public const string TotalAverageGradeMsg = "Total average grade: {0:F2}";

        //help
        public const string AvailableCommands = "{0} - available commands:\r\n";

        //command info
        public const string CommandInfoMsg = "{0}\nFormat: {1}\nDescription: {2}\nExample: {3}";

        //Error Messages
        public const string CommandFormatErrorMsg = "Command is not in the specified format.";
        public const string StudentNotFoundMsg = "The student could not be found";
        public const string CourseNotFoundMsg = "The course could not be found";
        public const string StudentExistsMsg = "Student already in school.";
        public const string CourseExistsMst = "Course already added to school";

        public const string CommandNotRecognizedMsg =
            "Command Not Recognized. Please enter a valid command or enter h for help";

        public const string NoGradesMsg = "Student has no grades yet";
        public const string TeacherExistsMsg = "Teacher already exists in school";
        public const string TeacherNotFoundMsg = "Teacher not found in school";
    }
}
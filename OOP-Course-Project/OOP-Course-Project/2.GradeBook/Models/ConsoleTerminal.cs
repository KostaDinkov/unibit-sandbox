using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using GradeBook.Common;
using GradeBook.Exceptions;

namespace GradeBook.Models
{
    public class ConsoleTerminal : ITerminal
    {
        private readonly School school;
        private List<CommandInfo> commandInfos;
        private readonly CommandValidator validator;


        public ConsoleTerminal(School school)
        {
            this.school = school;
            this.IsRunning = true;
            this.ReadCommandInfo();
            this.validator = new CommandValidator();
        }

        public bool IsRunning { get; set; }

        public void ReadCommand()
        {
            try
            {
                var commandLine = Console.ReadLine().Split(":");
                var command = commandLine[0].Trim();

                switch (command)
                {
                    case "add-student":
                    {
                        var studentName = this.validator.ValidateAddPerson(command, commandLine);
                        this.school.AddStudent(new Student {FullName = studentName});
                        this.Log(Messages.StudentAddedMsg, studentName);
                        break;
                    }
                    case "add-course":
                    {
                        var (semester, courseName, lectureHours, practiceHours) =
                            this.validator.ValidateAddCourse(command, commandLine);
                        var course = new Course
                        {
                            Name = courseName,
                            LectureCount = lectureHours,
                            PracticeCount = practiceHours,
                            Semester = semester
                        };
                        this.school.AddCourse(course);
                        this.Log(Messages.CourseAddedMsg, course.Name);
                        break;
                    }
                    case "get-courses":
                    {
                        var result = this.school.GetCoursesString();
                        this.Log(result);
                        break;
                    }
                    case "add-grade":
                    {
                        var (studentName, courseName, grade) =
                            this.validator.ValidateAddGrade(command, commandLine);
                        this.school.AddGrade(studentName, courseName, grade);
                        this.Log(Messages.GradeAddedMsg, courseName, grade.ToString(CultureInfo.InvariantCulture),
                            studentName);
                        break;
                    }
                    case "add-grades-bulk":
                    {
                        var data = Console.ReadLine().Split(";");
                        var (studentName, courseInfos) =
                            this.validator.ValidateAddGradesBulk(command, commandLine, data);

                        this.school.AddGradesBulk(studentName, courseInfos);
                        this.Log(Messages.GradesAdded);
                        break;
                    }
                    case "get-grades":
                    {
                        var studentName = this.validator.ValidateGetGrades(command, commandLine);
                        var result = this.school.GetGradesString(studentName);
                        this.Log(result);
                        break;
                    }
                    case "get-semester-stats":
                    {
                        var studentName = this.validator.ValidateGetSemesterStats(command, commandLine);
                        var result = this.school.GetSemesterStats(studentName);
                        this.Log(result);
                        break;
                    }
                    case "get-students":
                    {
                        this.Log(this.school.GetStudentsString());
                        break;
                    }
                    case "h":
                    {
                        this.Log(this.GetCommandHelp());
                        break;
                    }
                    case "exit":
                    {
                        this.IsRunning = false;
                        break;
                    }
                    case "add-teacher":
                        string teacherFullName = this.validator.ValidateAddPerson(command, commandLine);
                        this.school.AddTeacher(new Teacher { FullName = teacherFullName });
                        
                        break;
                    case "get-teachers":
                        this.Log(this.school.GetTeachersString());
                        break;
                    case "add-teacher-to-course":
                        var (tName, cName) = this.validator.ValidateAddTeacherToCourse(command, commandLine);
                        this.school.AddTeacherToCourse(tName, cName);
                        break;
                    default:
                    {
                        this.Log(Messages.CommandNotRecognizedMsg);
                        break;
                    }
                }
            }
            catch (Exception e) when (e is CommandFormatException || e is NotFoundException ||
                                      e is EntityExistsException)
            {
                if (e is CommandFormatException)
                {
                    var command = e.Message.Split("\n")[1];
                    var message = this.commandInfos.FirstOrDefault(ci => ci.Name == command)?.Format;

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        this.Log(Messages.CommandFormatErrorMsg + "\n" + message);
                        return;
                    }
                    
                }
                this.Log(e.Message);
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Start()
        {
            this.Log(Messages.OOPMessage);
            this.Log(new String('-',30));
            this.Log(Messages.WelcomeMsg, this.school.Name);
            
            while (this.IsRunning)
            {
                this.ReadCommand();
            }
        }

        public void Log(string message, params string[] msgParams)
        {
            Console.WriteLine(message, msgParams);
        }

        /// <summary>
        ///     Return a list of the available console commands
        /// </summary>
        /// <returns></returns>
        private string GetCommandHelp()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(Messages.AvailableCommands, this.school.Name) + new string('-', 20));

            foreach (var commandInfo in this.commandInfos)
            {
                sb.AppendLine(commandInfo.ToString());
                sb.AppendLine(new string('-', 20));
            }

            return sb.ToString();
        }

        private void ReadCommandInfo()
        {
            var jsonInfo = File.ReadAllText(Program.CommandInfoFilePath);
            this.commandInfos = JsonSerializer.Deserialize<List<CommandInfo>>(jsonInfo);
        }
    }
}
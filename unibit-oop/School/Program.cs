using System;
using System.Text;

namespace School
{
    internal class Program
    {
        private static School university = new School();
        private static void Main()
        {
            university.Name = "Kiberlab University";
            Console.WriteLine($"{university.Name} management system");
            Console.WriteLine("Please enter a command or type 'help' to view available commands.");

            bool over = false;
            while (!over)
            {
                Console.Write(">>>");
                var command = Console.ReadLine();
                
                switch (command)
                {
                    case "end": 
                        over = true;
                        break;
                    case "help": PrintHelp();
                        break;
                    case "add course": 
                        AddCourse();
                        break;
                    case "all courses":
                        GetAllCourses();
                        break;
                    
                    default:
                        Console.WriteLine("Command not recognized, please try again");
                        break;
                }

                
            }

            //var student1 = new Student("Trendafil", "Akaciev", "trendafil@university.edu");
            //var student2 = new Student("Kifla", "Silikonova", "kifli4ka@university.edu");

            //var jelezen = new Teacher("Stoman", "Jelyazkov", "jelezen@university.edu");

            //university.Students.Add(student1);
            //university.Students.Add(student2);
            //university.Teachers.Add(jelezen);

            //var la101 = new Course
            //{
            //    CourseId = "LA101", Name = "Linear Algebra",
            //    Description = "This course introduces the basics of linear algebra"
            //};

            //la101.Teacher = jelezen;
            //la101.Students.Add(student1);
            //la101.Students.Add(student2);

            //university.Courses.Add(la101);

            //Console.WriteLine(student1.GetInfo());
        }

        private static void GetAllCourses()
        {
            if (university.Courses.Count == 0)
            {
                Console.WriteLine($"{university.Name} has no courses yet.");
            }
            var sb = new StringBuilder();
            foreach (var course in university.Courses)
            {
                sb.AppendLine($"{course.CourseId} - {course.Name}");
               
            }

            Console.WriteLine(sb.ToString());
        }

        private static void AddCourse()
        {
            var course = new Course();

            Console.Write("Enter course name: ");
            string name = Console.ReadLine();
            //todo check name

            Console.Write("Enter course code");
            string code = Console.ReadLine();
            //todo check code

            Console.Write("Enter short description: ");
            string description = Console.ReadLine();
            //todo check description


            university.Courses.Add(new Course(){CourseId = code, Name = name, Description = description});
        }

        private static void PrintHelp()
        {
            throw new NotImplementedException();
        }
    }
}
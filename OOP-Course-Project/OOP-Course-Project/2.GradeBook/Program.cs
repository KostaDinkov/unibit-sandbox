using GradeBook.Models;

namespace GradeBook
{
    public class Program
    {
        public const string CommandInfoFilePath = "command-help.json";

        public static void Main()
        {
            var school = new School("Unibit");
            var terminal = new ConsoleTerminal(school);
            terminal.Start();
        }
    }
}
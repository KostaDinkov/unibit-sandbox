namespace GradeBook.Models
{
    public interface ITerminal
    {
        public bool IsRunning { get; set; }
        public void ReadCommand();

        public void Log(string message);
        public void Start();
    }
}
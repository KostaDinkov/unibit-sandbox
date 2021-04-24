using GradeBook.Common;

namespace GradeBook.Models
{
    public class CommandInfo
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }

        public string Example { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    Messages.CommandInfoMsg,
                    this.Name,
                    this.Format,
                    this.Description,
                    this.Example);
        }
    }
}
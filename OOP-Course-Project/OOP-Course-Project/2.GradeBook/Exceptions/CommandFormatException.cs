using System;
using GradeBook.Common;

namespace GradeBook.Exceptions
{
    public class CommandFormatException : Exception
    {
        public CommandFormatException() : base(Messages.CommandFormatErrorMsg)
        {
        }

        public CommandFormatException(string msg) : base(Messages.CommandFormatErrorMsg + "\n" + msg)
        {
        }
    }
}
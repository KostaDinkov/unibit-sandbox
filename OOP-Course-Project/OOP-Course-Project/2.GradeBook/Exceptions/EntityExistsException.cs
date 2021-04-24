using System;

namespace GradeBook.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string msg) : base(msg)
        {
        }
    }
}
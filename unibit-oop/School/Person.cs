using System;

namespace School
{
    public abstract class Person
    {
        
        protected  Person(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Id = Guid.NewGuid();

        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public Guid Id { get; private set; }

        public string Email { get; set; }

        public virtual string GetInfo()
        {
            return $"{this.FirstName} {this.LastName} {this.Id}";
        }
        
    }
}
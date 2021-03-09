using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public class Student
    {
        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }
        private string name;
        public string Email { get; set; }
        public string Name
        {
            get => name;
            set
            {
                Validator.NameValidation(value, "Name cannot contain special characters or letters");
                name = value;
            }
        }
    }
}

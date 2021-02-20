using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {
        public Student(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }
        private string firstName;
        private string lastName;
        private string subject;
        public string FirstName { get => firstName; set { firstName = value; } }
        public string LastName { get => lastName; set { lastName = value; } }
        public string Subject { get => subject; set { subject = value; } }

        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}

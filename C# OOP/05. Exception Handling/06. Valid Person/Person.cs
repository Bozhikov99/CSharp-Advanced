using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        { 
            get=>firstName;
            set
            {
                Validator.NameValidation(value, "The first name cannot be null or empty.");
                firstName = value;
            }
        }
        public string LastName
        { 
            get=>lastName;
            set
            {
                Validator.NameValidation(value, "The last name cannot be null or empty.");
                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                Validator.AgeValidation(value, "Age should be in the age of [0 ... 120]");
                age = value;
            }
        }

    }
}

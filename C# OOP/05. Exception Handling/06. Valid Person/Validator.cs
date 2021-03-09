using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public static class Validator
    {
        public static void NameValidation(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void AgeValidation(int value, string message)
        {
            if (value<0||value>120)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}

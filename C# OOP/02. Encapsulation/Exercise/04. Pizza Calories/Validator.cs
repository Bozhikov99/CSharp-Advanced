using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowArgumentException(string value, int minLength, int maxLength, string message)
        {
            if (value.Length<minLength||value.Length>maxLength)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowInvalidValue(string value, HashSet<string> values, string message)
        {
            if (!values.Contains(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowInvalidWeight(int value, int min, int max, string message)
        {
            if (value<min||value>max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}

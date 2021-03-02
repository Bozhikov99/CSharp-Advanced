using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowEmptyName(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowInvalidValue(int value, int min, int max, string message)
        {
            if (value<min||value>max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}

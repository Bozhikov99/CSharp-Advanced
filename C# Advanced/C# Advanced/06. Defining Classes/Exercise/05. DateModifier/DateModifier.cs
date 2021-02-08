using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int Difference(string first, string second)
        {
            int[] firstDate = first
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondDate = second
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            DateTime a = Convert.ToDateTime(first);
            DateTime b = Convert.ToDateTime(second);
            int difference = Convert.ToInt32((a - b).TotalDays);

            return Math.Abs( difference);
        }
    }

}

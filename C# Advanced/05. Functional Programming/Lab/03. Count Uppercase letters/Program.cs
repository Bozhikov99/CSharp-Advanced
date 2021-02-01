using System;
using System.Linq;

namespace _03._Count_Uppercase_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperCheck = w => char.IsUpper(w[0]);
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCheck)
                .ToArray();

            foreach (string u in words)
            {
                Console.WriteLine(u);
            }
        }
    }
}

using System;
using System.Linq;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = string.Join(" ", firstLine.SkipLast(1));

            Console.WriteLine(new Tuple<string, string>(fullName, firstLine[2]).ToString());

            string[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1])).ToString());

            string[] thirdLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1])).ToString());
        }
    }
}

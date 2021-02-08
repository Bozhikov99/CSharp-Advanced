using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = string.Join(" ", firstLine.SkipLast(1));

            Console.WriteLine(new Threeuple<string, string, string>(fullName, firstLine[2], firstLine[3]).ToString());

            string[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool state = secondLine[2] == "drunk";

            Console.WriteLine(new Threeuple<string, int, bool>(secondLine[0], int.Parse(secondLine[1]), state).ToString());

            string[] thirdLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(new Threeuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]).ToString());
        }
    }
}

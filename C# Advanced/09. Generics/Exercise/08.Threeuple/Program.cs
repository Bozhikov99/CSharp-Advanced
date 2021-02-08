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

            string fullName = $"{firstLine[0]} {firstLine[1]}";
            string homeTown = string.Join(" ",firstLine.Skip(3));

            Console.WriteLine(new Threeuple<string, string, string>(fullName, firstLine[2], homeTown).ToString());

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

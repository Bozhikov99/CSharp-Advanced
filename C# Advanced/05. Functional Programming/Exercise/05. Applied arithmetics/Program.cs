using System;
using System.Linq;

namespace _05._Applied_arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Action<string> operation = x =>
            {
                    switch (x)
                {
                    case "add":
                        numbers = numbers.Select(x => ++x).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => --x).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x *= 2).ToArray();
                        break;
                    default:
                        break;
                }
            };

            string cmd = Console.ReadLine();
            while (cmd!="end")
            {
                operation(cmd);
                cmd = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.XPath;

namespace _06._Reverse_and_exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int,List<int>> revEx = (x, n) =>
            {
                for (int i = 0; i<x.Count; i++)
                {
                    if (x[i] % n == 0)
                    {
                        x.RemoveAt(i);
                        i--;
                    }
                }
                return x;
            };

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divident = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ",revEx(numbers, divident)));
        } 
    }
}

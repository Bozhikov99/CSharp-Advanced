using System;
using System.Linq;

namespace _04._Add_VAt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(x=>x*1.2m)
                .ToList<decimal>()
                .ForEach(x=>Console.WriteLine($"{x:f2}"));
        }
    }
}

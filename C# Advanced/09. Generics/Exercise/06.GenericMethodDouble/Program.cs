using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.GenericMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }
            Console.WriteLine(Compare(double.Parse(Console.ReadLine()), list));
        }

        public static int Compare<T>(T element, List<T> list)
            where T : IComparable
        {
            return list.Where(x => x.CompareTo(element) > 0).ToList().Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            Console.WriteLine(Compare(Console.ReadLine(), list));
        }

        public static int Compare<T>(T element, List<T> list)
            where T : IComparable
        {
            return list.Where(x => x.CompareTo(element) > 0).ToList().Count;
        }
    }
}

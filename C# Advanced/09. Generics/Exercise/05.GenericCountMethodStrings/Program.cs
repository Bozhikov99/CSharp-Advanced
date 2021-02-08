using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }
            Console.WriteLine(Compare(new Box<string>(Console.ReadLine()), list));
        }
        public static int Compare<T>(Box<T> box, List<Box<T>> list)
            where T : IComparable
        {
            int count = 0;
            foreach (Box<T> b in list)
            {
                if (b.Value.CompareTo(box.Value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

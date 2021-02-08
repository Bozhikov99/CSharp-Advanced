using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapInt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(indexes[0], indexes[1], list);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
        public static void Swap<T>(int a, int b, List<T> list)
        {
            T save = list[a];
            list[a] = list[b];
            list[b] = save;
        }
    }
}

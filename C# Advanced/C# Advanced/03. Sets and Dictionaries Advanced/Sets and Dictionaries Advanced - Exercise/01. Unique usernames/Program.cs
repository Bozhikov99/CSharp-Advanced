using System;
using System.Collections.Generic;

namespace _01._Unique_usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> nameSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                nameSet.Add(Console.ReadLine());
            }
            foreach (string name in nameSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}

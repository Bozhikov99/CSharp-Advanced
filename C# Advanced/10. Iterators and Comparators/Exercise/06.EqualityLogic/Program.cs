using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> people = new SortedSet<Person>();
            HashSet<Person> peopleHash = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(cmd[0], int.Parse(cmd[1])));
                peopleHash.Add(new Person(cmd[0], int.Parse(cmd[1])));
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(peopleHash.Count);
        }
    }
}

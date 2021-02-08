using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = cmd[0];
                int age = int.Parse(cmd[1]);

                people.Add(new Person(name, age));
            }

            people = people.Where(m => m.Age > 30)
                .OrderBy(m => m.Name)
                .ToList();

            foreach (Person m in people)
            {
                Console.WriteLine($"{m.Name} - {m.Age}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_by_Age
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = cmd[0];
                int age = int.Parse(cmd[1]);

                people[i] = new Person(name, age);
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string formatInput=Console.ReadLine();
            Output(people, Filter(filter, filterAge), Format(formatInput));
        }

        static Func<Person, string> Format(string format)
        {
            switch (format)
            {
                case "age": return p => $"{p.Age}";
                case "name": return p => $"{p.Name}";
                case "name age": return p => $"{p.Name} - {p.Age}";
                default: return null;
            }
        }
        static Func<Person, bool> Filter(string filter, int age)
        {
            switch (filter)
            {
                case "younger": return p=>p.Age<=age;
                case "older": return p => p.Age >= age;
                default: return null;
            }
        }

        static void Output(Person[] people, Func<Person, bool> filter, Func<Person, string> format)
        {
            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine(format(p));
                }
            }
        }
    } 
}

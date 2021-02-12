using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (cmd != "END")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));

                cmd = Console.ReadLine();
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            Person comparedPerson = people[index];
            List<Person> compareList = new List<Person>();

            for (int i = 0; i < people.Count; i++)
            {
                if (i != index)
                {
                    compareList.Add(people[i]);
                }
            }

            int matches = 0;
            int notEqual = 0;

            foreach (var p in compareList)
            {
                int current = comparedPerson.CompareTo(p);

                if (current == 0)
                {
                    if (matches==0)
                    {
                        matches += 2;
                    }
                    else
                    {
                        matches++;
                    }
                }
                else
                {    
                        notEqual++;
                }
            }
            string output = matches == 0 ? "No matches" : $"{matches} {notEqual} {people.Count}";
            Console.WriteLine(output);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _11._Party_reservation_filter_module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> filters = new List<string>();
            List<string> guests = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string cmd = Console.ReadLine();
            while (cmd != "Print")
            {//Add filter;Starts with;P
                string[] tokens = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filterArgs = cmd.Substring(cmd.IndexOf(';'));

                if (command == "Add filter")
                {
                    filters.Add(filterArgs);
                }
                else if (command=="Remove filter")
                {
                    filters.Remove(filterArgs);
                }
                cmd = Console.ReadLine();
            }

            foreach (string filter in filters)
            {
                //Starts with;P               
                string[] filterArgs = filter.Split(';', StringSplitOptions.RemoveEmptyEntries);
                Predicate<string> currentFilter = PredicatorGenerator(filterArgs);
                guests.RemoveAll(currentFilter);
            }
            Console.WriteLine(string.Join(' ',guests));
        }

        public static Predicate<string> PredicatorGenerator(string[] filterArgs)
        {
            Predicate<string> newFilter;
            string type = filterArgs[0];
            string argument = filterArgs[1];

            switch (type)
            {
                case "Starts with":
                    newFilter = new Predicate<string>(n => n.StartsWith(argument));
                    break;
                case "Ends with":
                    newFilter = new Predicate<string>(n => n.EndsWith(argument));
                    break;
                case "Contains":
                    newFilter = new Predicate<string>(n=>n.Contains(argument));
                    break;
                case "Length":
                    newFilter = new Predicate<string>(n=>n.Length==int.Parse(argument));
                    break;
                
                default:
                    newFilter = null;
                    break;
            }
            return newFilter;
        }
    }
}

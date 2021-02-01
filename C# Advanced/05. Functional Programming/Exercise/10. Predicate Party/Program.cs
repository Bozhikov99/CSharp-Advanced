using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _10._Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string cmd = Console.ReadLine();
            while (cmd != "Party!")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string[] predArgs = tokens.Skip(1)
                    .ToArray();
                Predicate<string> predicate = PredGen(predArgs);
                switch (command)
                {
                    case "Remove":
                        guests.RemoveAll(predicate);
                        break;
                    case "Double":
                        for (int i = 0; i < guests.Count; i++)
                        {
                            string currentName = guests[i];
                            if (predicate(currentName))
                            {
                                guests.Insert(i+1, currentName);
                                i++;
                            }
                        }
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }
            string output = guests.Count > 0 ? $"{string.Join(", ", guests)} are going to the party!" :
                $"Nobody is going to the party!";
            Console.WriteLine(output);
        }

        public static Predicate<string> PredGen(string[] predArgs)
        {
            Predicate<string> predicate = null;
            string criteria = predArgs[0];
            string argument = predArgs[1];

            switch (criteria)
            {
                case "StartsWith":
                    predicate = new Predicate<string>(n => n.StartsWith(argument));
                    break;
                case "EndsWith":
                    predicate = new Predicate<string>(n => n.EndsWith(argument));
                    break;
                case "Length":
                    predicate = new Predicate<string>(predicate = n => n.Length == int.Parse(argument));
                    break;
                default:
                    break;
            }
            return predicate;
        }
    }
}

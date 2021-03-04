using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] tokens = cmd.Split();
                string type = tokens[0];
                string name = tokens[1];

                if (type == nameof(Citizen))
                {
                    //Citizen Pesho 22 9010101122 10/10/1990
                    birthables.Add(new Citizen(name, int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (type == nameof(Pet))
                {
                    birthables.Add(new Pet(name, tokens[2]));
                }

                cmd = Console.ReadLine();
            }

            string filterDate = Console.ReadLine();

            foreach (var birthable in birthables.Where(b => b
            .Birthdate
            .EndsWith(filterDate)))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}

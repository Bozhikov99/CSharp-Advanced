using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string cmd = Console.ReadLine();
            while (cmd != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!trainers.Any(x=>x.Name==tokens[0]))
                {
                    trainers.Add(new Trainer(tokens[0]));
                }
                trainers.First(t=>t.Name==tokens[0]).Collection
                    .Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));

                cmd = Console.ReadLine();
            }

            cmd = Console.ReadLine();
            while (cmd!="End")
            {
                foreach (Trainer t in trainers)
                {
                    if (t.Collection.Any(p=>p.Element==cmd))
                    {
                        t.Badges++;
                    }
                    else
                    {
                        foreach (Pokemon p in t.Collection)
                        {
                            p.Health -= 10;
                        }
                        t.Collection = t.Collection.Where(p => p.Health > 0).ToList();
                    }
                }

                cmd = Console.ReadLine();
            }

            foreach (Trainer t in trainers.OrderByDescending(t=>t.Badges))
            {
                Console.WriteLine($"{t.Name} {t.Badges} {t.Collection.Count}");
            }
        }
    }
}

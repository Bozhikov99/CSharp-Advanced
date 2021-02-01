using System;
using System.Collections.Generic;

namespace _04._Cities_by_continent_and_country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = cmd[0];
                string country = cmd[1];
                string city = cmd[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                    continents[continent][country].Add(city);
                }
                else
                {
                    if (!continents[continent][country].Contains(city))
                    {
                        continents[continent][country].Add(city);
                    }
                }
            }
            foreach (var c in continents)
            {
                Console.WriteLine($"{c.Key}:");
                foreach (var country in c.Value)
                {
                    Console.Write($"    {country.Key} -> ");
                    Console.WriteLine($"{string.Join(", ",c.Value)}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> websites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationary = new StationaryPhone();

            foreach (string n in phoneNumbers)
            {
                if (n.Length == 10)
                {
                    Console.WriteLine(smartphone.Dial(n));
                }
                else
                {
                    Console.WriteLine(stationary.Dial(n));
                }
            }

            foreach (string site in websites)
            {
                Console.WriteLine(smartphone.Browse(site));
            }
        }
    }
}

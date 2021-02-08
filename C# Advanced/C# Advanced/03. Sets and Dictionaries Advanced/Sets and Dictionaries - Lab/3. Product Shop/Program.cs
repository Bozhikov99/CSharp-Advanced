using System;
using System.Collections.Generic;
using System.Linq;


namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();

            string[] cmd = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0]!="Revision")
            {
                string shop = cmd[0];   
                string product = cmd[1];
                double price = double.Parse(cmd[2]);
                cmd = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop][product] = price;
            }
            foreach (var shop in shops.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var p in shop.Value)
                {
                    Console.WriteLine($"Product: {p.Key}, Price: {p.Value}");
                }
            }
        }
    }
}

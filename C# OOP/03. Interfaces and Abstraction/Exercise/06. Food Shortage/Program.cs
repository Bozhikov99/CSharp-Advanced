using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] current = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //Pesho 25 8904041303 04/04/1989
                //Stancho 27 WildMonkeys
                string name = current[0];
                int age = int.Parse(current[1]);

                if (current.Length==3)
                {
                    buyers[name]=new Rebel(name, age, current[2]);
                }
                else if (current.Length==4)
                {
                    buyers[name] = new Citizen(name, age, current[2], current[3]);
                }
            }

            string cmd = Console.ReadLine();

            while (cmd!="End")
            {
                if (buyers.ContainsKey(cmd))
                {
                    buyers[cmd].BuyFood();
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine(buyers.Values.Sum(b=>b.Food));
          
        }
    }
}

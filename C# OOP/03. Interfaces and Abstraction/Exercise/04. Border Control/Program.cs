using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IRobot> inhabitants= new List<IRobot>();
            string cmd = Console.ReadLine();

            while (cmd!="End")
            {
                string[] tokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (tokens.Length==2)
                {
                    inhabitants.Add(new Robot(tokens[0], tokens[1]));
                }
                else
                {
                    inhabitants.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                cmd = Console.ReadLine();
            }

            string invalidNum = Console.ReadLine();

            foreach (var i in inhabitants.Where(i=>i.Id.EndsWith(invalidNum)))
            {
                Console.WriteLine(i.Id);
            }
           
        }
    }
}

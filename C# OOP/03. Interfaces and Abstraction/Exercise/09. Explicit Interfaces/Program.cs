using ExplicitInterfeces;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();

            while (cmd!="End")
            {
                //PeshoPeshev Bulgaria 20
                string[] data = cmd.Split();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                Citizen current = new Citizen(name, country, age);
                Console.WriteLine(((IPerson)current).GetName());
                Console.WriteLine(((IResident)current).GetName());

                cmd = Console.ReadLine();
            }

        }
    }
}

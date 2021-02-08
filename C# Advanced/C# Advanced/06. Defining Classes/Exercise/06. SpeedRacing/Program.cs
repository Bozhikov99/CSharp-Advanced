using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace DefineClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                carList.Add(new Car(cmd[0], double.Parse(cmd[1]), double.Parse(cmd[2])));
            }

            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (tokens[0]!="End")
            {
                string currentMode = tokens[1];
                double kms = double.Parse(tokens[2]);

                carList[carList.IndexOf(carList.Where(x => x.Model == currentMode).First())].Drive(kms);

                tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (Car c in carList)
            {
                Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.TravelledDistance}");
            }
        }
    }
}

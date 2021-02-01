using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmd.Length == 2)
                {
                    engines.Add(new Engine(cmd[0], cmd[1]));
                }
                else if (cmd.Length == 3)
                {
                    if (char.IsDigit(cmd[2].First()))
                    {
                        engines.Add(new Engine(cmd[0], cmd[1], int.Parse(cmd[2])));
                    }
                    else
                    {
                        engines.Add(new Engine(cmd[0], cmd[1], cmd[2]));
                    }
                }
                else if (cmd.Length==4)
                {
                    engines.Add(new Engine(cmd[0], cmd[1], int.Parse(cmd[2]), cmd[3]));
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = engines.Where(e => e.Model == cmd[1]).First();

                if (cmd.Length==4)
                {
                    cars.Add(new Car(cmd[0], currentEngine, int.Parse(cmd[2]), cmd[3]));
                }
                else if (cmd.Length==3)
                {
                    if (char.IsDigit(cmd[2].First()))
                    {
                        cars.Add(new Car(cmd[0], currentEngine, int.Parse(cmd[2])));
                    }
                    else
                    {
                        cars.Add(new Car(cmd[0], currentEngine, cmd[2]));
                    }
                }
                else if (cmd.Length==2)
                {
                    cars.Add(new Car(cmd[0], currentEngine));
                }
            }

            foreach (Car c in cars)
            {
                string engineDisplacementOutput = c.CarEngine.Displacement != -1 ? 
                    c.CarEngine.Displacement.ToString() :
                    "n/a";

                string carWeightOutput = c.Weight != -1 ?
                    c.Weight.ToString() :
                    "n/a";

                Console.WriteLine($"{c.Model}:");
                Console.WriteLine($"  {c.CarEngine.Model}:");
                Console.WriteLine($"    Power: {c.CarEngine.Power}");
                Console.WriteLine($"    Displacement: {engineDisplacementOutput}");
                Console.WriteLine($"    Efficiency: {c.CarEngine.Efficiency}");
                Console.WriteLine($"  Weight: {carWeightOutput}");
                Console.WriteLine($"  Color: {c.Color}");
            }
        }
    }
}

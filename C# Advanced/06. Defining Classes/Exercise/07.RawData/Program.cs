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

            for (int i = 0; i < n; i++)
            {
                //model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = cmd[0];
                int engineSpeed = int.Parse(cmd[1]);
                int enginePower = int.Parse(cmd[2]);
                int cargoWeight = int.Parse(cmd[3]);
                string cargoType = cmd[4];
                Tire[] currentTires = new Tire[4];
                int tireCounter = 0;

                for (int j = 0; j < 8; j++)
                {
                    double pressure = double.Parse(cmd[5 + j]);
                    int year = int.Parse(cmd[6 + j]);
                    j++;
                    currentTires[tireCounter] = new Tire(year, pressure);
                    tireCounter++;
                }
                cars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoType, cargoWeight), currentTires));
            }

            string sortType = Console.ReadLine();
            if (sortType == "fragile")
            {
                foreach (Car c in cars
                    .Where(c=>c.Cargo.Type=="fragile"&&c.Tires.Any(c=>c.Pressure<1)))
                {
                    Console.WriteLine($"{c.Model}");
                }
            }
            else
            {
                foreach (Car c in cars
                    .Where(c=>c.Cargo.Type=="flamable"&&c.CarEngine.Power>250))
                {
                    Console.WriteLine($"{c.Model}");
                }
            }
        }
    }
}

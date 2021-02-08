using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> carList = new List<Car>();

            string cmd = Console.ReadLine();

            while (cmd != "No more tires")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] currentTires = new Tire[tokens.Length / 2];
                int tireCounter = 0;

                for (int i = 0; i < tokens.Length; i += 2, tireCounter++)
                {
                    int tireYear = int.Parse(tokens[i]);
                    double tirePressure = double.Parse(tokens[i + 1]);
                    currentTires[tireCounter] = new Tire(tireYear, tirePressure);
                }
                tires.Add(currentTires);
                cmd = Console.ReadLine();
            }

            cmd = Console.ReadLine();
            while (cmd != "Engines done")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapactiy = double.Parse(tokens[1]);

                Engine newEngine = new Engine(horsePower, cubicCapactiy);
                engines.Add(newEngine);

                cmd = Console.ReadLine();
            }

            cmd = Console.ReadLine();
            while (cmd != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tireIndex = int.Parse(tokens[6]);

                carList.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]));
                cmd = Console.ReadLine();
            }

            Predicate<Car> isSpecial = c =>
             {
                 if (c.Year >= 2017 &&
                     c.Engine.HorsePower >= 330 &&
                     c.Tires.Sum(x => x.Pressure) >= 9 &&
                     c.Tires.Sum(x => x.Pressure) <= 10)
                 {
                     return true;
                 }
                 return false;
             };

            carList = carList.Where(x=>isSpecial(x)).ToList();
            foreach (Car c in carList)
            {
                c.Drive(20);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Make: {c.Make}");
                sb.AppendLine($"Model: {c.Model}");
                sb.AppendLine($"Year: {c.Year}");
                sb.AppendLine($"HorsePowers: {c.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {c.FuelQuantity}");
                Console.WriteLine(sb);
            }
        }
    }
}

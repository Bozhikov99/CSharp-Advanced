using System;
using Vehicles.Contracts;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine()
                .Split();                           //Car 15 0.3

            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));

            string[] truckData = Console.ReadLine()
                .Split();

            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] currentCmd = Console.ReadLine()
                    .Split();

                string type = currentCmd[1];
                string command = currentCmd[0];
                double amount = double.Parse(currentCmd[2]);

                if (type==nameof(Car))
                {
                    if (command=="Drive")
                    {
                        Console.WriteLine(car.Drive(amount));
                    }
                    else
                    {
                        car.Refuel(amount);
                    }
                }
                else if (type==nameof(Truck))
                {
                    if (command=="Drive")
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        } 
    }
}

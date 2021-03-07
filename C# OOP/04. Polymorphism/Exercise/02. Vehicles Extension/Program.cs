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

            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));

            string[] truckData = Console.ReadLine()
                .Split();

            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));

            string[] busData = Console.ReadLine()
                .Split();

            Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] currentCmd = Console.ReadLine()
                    .Split();

                string type = currentCmd[1];
                string command = currentCmd[0];
                double amount = double.Parse(currentCmd[2]);

                if (command=="Refuel")
                {
                    if (type == nameof(Truck))
                    {
                        truck.Refuel(amount);
                    }
                    else if(type == nameof(Car))
                    {
                        car.Refuel(amount);
                    }
                    else if (type==nameof(Bus))
                    {
                        bus.Refuel(amount);
                    }
                }
                else if (command == "Drive")
                {
                    if (type == nameof(Truck))
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                    else if(type==nameof(Car))
                    {
                        Console.WriteLine(car.Drive(amount));
                    }
                    else if (type==nameof(Bus))
                    {
                        Console.WriteLine(bus.Drive(amount));
                    }
                }
                else if (command=="DriveEmpty")
                {
                    Console.WriteLine(bus.DriveEmpty(amount));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        } 
    }
}

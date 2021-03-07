using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public class Truck : Vehicle, IDrivable
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm+1.6,tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            double decreasedFuel = fuel * 0.95;
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            FuelQuantity += decreasedFuel;
        }
    }
}

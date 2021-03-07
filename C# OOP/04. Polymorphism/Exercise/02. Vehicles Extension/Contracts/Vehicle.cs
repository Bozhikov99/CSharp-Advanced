using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public class Vehicle : IDrivable
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            TankCapacity = tankCapacity;
        }
        public double FuelConsumptionPerKm { get; private set; }

        public double FuelQuantity { get; set; }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double km)
        {
            double fuelNeeded = km * FuelConsumptionPerKm;

            if (FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                return $"{GetType().Name} travelled {km} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity+fuel>TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public class Vehicle : IDrivable
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        public double FuelConsumptionPerKm { get; private set; }

        public double FuelQuantity { get;private set; }

        public string Drive(double km)
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
            FuelQuantity+=fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}

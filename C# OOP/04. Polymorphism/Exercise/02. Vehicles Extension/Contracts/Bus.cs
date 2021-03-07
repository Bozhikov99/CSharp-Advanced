using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public class Bus : Vehicle, IDrivable
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double km)
        {
            double fuelNeeded = km * (FuelConsumptionPerKm+1.4);

            if (FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                return $"{GetType().Name} travelled {km} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public string DriveEmpty(double km)
        {
            double fuelNeeded = km * FuelConsumptionPerKm;

            if (FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                return $"{GetType().Name} travelled {km} km";
            }
            return $"{GetType().Name} needs refueling";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public class Truck : Vehicle, IDrivable
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm+1.6)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel*0.95);
        }
    }
}

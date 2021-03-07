using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public class Car : Vehicle, IDrivable
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) : 
            base(fuelQuantity, fuelConsumptionPerKm+0.9)
        {

        }
    }
}

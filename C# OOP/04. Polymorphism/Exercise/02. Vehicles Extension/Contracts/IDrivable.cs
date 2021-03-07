using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public interface IDrivable
    {
        double FuelConsumptionPerKm { get; }
        double FuelQuantity { get; }
        double TankCapacity { get; }
        string Drive(double km);
        void Refuel(double fuel);
    }
}

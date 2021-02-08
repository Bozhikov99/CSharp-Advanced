using System;
using System.Collections.Generic;
using System.Text;

namespace DefineClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
            TravelledDistance = 0;
        }

        public void Drive(double km)
        {
            if (FuelAmount >= km * FuelConsumptionPerKilometer)
            {
                FuelAmount -= km * FuelConsumptionPerKilometer;
                TravelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

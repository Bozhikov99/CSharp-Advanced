﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        private const double defaultFuelConsumption=8;
        public override double FuelConsumptionPerKilometer => defaultFuelConsumption;
    }
}

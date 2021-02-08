using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }
        public string Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, string power)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficiency = "n/a";
        }

        public Engine(string model, string power, int displacement)
            :this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, string power, string efficiency)
            :this(model, power)
        {
            Efficiency = efficiency;
        }
        public Engine(string model, string power, int displacement, string efficiency)
            :this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }
    }
}

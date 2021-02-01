using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine carEngine)
        {
            Model = model;
            CarEngine = carEngine;
            Weight = -1;
            Color = "n/a";
        }

        public Car(string model, Engine carEngine, int weight)
            :this(model, carEngine)
        {
            Weight = weight;
        }

        public Car(string model, Engine carEngine, string color)
            :this(model, carEngine)
        {
            Color = color;
        }

        public Car(string model, Engine carEngine, int weight, string color)
            :this(model, carEngine)
        {
            Weight = weight;
            Color = color;
        }
    }
}

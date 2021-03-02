using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        private const int minWeight = 1;
        private const int maxWeight = 50;

        private string name;
        private int weight;

        public string Name
        {
            get => name;
            private set
            {
                string valueToLower = value.ToLower();
                Validator.ThrowInvalidValue(valueToLower, new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, $"Cannot place {value} on top of your pizza.");
                name = value;
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowInvalidWeight(value, minWeight, maxWeight, $"{Name} weight should be in the range [1..50].");
                weight = value;
            }
        }

        public double GetCalories()
        {
            double modifier = 0;

            if (Name.ToLower() == "meat")
            {
                modifier = 1.2;
            }
            else if (Name.ToLower() == "cheese")
            {
                modifier = 1.1;
            }
            else if (Name.ToLower() == "veggies")
            {
                modifier = 0.8;
            }
            else if (Name.ToLower() == "sauce")
            {
                modifier = 0.9;
            }

            return weight * 2 * modifier;
        }
    }
}
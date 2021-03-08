using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        private const double foodModifier = 0.25;
        private static HashSet<string> foods = new HashSet<string> { nameof(Meat) };
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, foods, foodModifier)
        {
        }

        public override string Sound()
        {
            return $"Hoot Hoot";
        }
    }
}

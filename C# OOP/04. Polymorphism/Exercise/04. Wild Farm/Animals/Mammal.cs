using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion , HashSet<string> foods, double foodModifier) 
            : base(name, weight, foods, foodModifier)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

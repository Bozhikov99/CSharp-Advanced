using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Felines : Mammal
    {
        public Felines(string name, double weight, string livingRegion, string breed, HashSet<string> foods, double foodModifier) 
            : base(name, weight, livingRegion, foods, foodModifier)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

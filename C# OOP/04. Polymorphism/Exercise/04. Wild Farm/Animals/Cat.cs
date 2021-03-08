using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Felines
    {
        private const double foodModifier = 0.3;
        private static HashSet<string> foods = new HashSet<string> {nameof(Meat), nameof(Vegetable) };
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, foods, foodModifier)
        {
        }

        public override string Sound()
        {
            return $"Meow";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Tiger : Felines
    {
        private const double foodModifier = 1.0;
        private static HashSet<string> foods = new HashSet<string> { nameof(Meat) };
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, foods, foodModifier)
        {
        }

        public override string Sound()
        {
            return "ROAR!!!";
        }
    }
}

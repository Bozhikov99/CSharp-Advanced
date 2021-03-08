using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        private const double foodModifier = 0.1;
        private static HashSet<string> foods= new HashSet<string> { nameof(Fruit), nameof(Vegetable) };
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, foods, foodModifier)
        {
        }

        public override string Sound()
        {
            return "Squeak";
        }
    }
}

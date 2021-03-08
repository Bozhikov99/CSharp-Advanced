using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        private const double foodModifier =0.4;
        private static HashSet<string> foods= new HashSet<string> { nameof(Meat) };
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, foods, foodModifier)
        {
        }

        public override string Sound()
        {
            return $"Woof!";
        }
    }
}

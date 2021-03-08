using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double foodModifier = 0.35;
        private static HashSet<string> foods=new HashSet<string> {nameof(Fruit),nameof(Vegetable),nameof(Meat),nameof(Seeds) } ;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, foods, foodModifier)
        {
        }

        public override string Sound()
        {
            return "Cluck";
        }
    }
}

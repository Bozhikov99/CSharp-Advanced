using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize, HashSet<string> foods, double foodModifier) 
            : base(name, weight, foods,foodModifier)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }
        public override string ToString()
        {
            //•	Birds – "{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}

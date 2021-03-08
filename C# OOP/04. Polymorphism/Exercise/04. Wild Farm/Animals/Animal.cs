using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight, HashSet<string> foods, double foodModifier)
        {
            Name = name;
            Weight = weight;
            FoodsAllowed = foods;
            FoodModifier = foodModifier;
        }
        private HashSet<string> FoodsAllowed { get; set; }
        public double FoodModifier { get; private set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; set; }

        public abstract string Sound();

        public abstract override string ToString();

        public void Eat(Food food)
        {
            if (!FoodsAllowed.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten+=food.Quantity;
            Weight += FoodModifier * food.Quantity;
        }
    }
}

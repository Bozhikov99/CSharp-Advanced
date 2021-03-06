using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favFood)
        {
            Name = name;
            FavouriteFood = favFood;
        }

        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return string.Empty;
        }
    }
}

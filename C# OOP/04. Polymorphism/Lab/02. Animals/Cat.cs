using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favFood) : base(name, favFood)
        {
        }

        public override string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavouriteFood}{Environment.NewLine}MEEOW";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Template_pattern
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-TwelveGrain Bread." );
        }
    }
}

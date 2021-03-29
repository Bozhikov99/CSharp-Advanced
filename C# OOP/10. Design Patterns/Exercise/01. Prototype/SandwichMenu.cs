using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Prototype
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => sandwiches[name];
            set => sandwiches.Add(name,value);
        }
    }
}

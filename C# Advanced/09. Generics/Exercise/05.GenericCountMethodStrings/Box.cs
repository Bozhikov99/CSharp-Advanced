using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _05.GenericCountMethodStrings
{
    public class Box<T> 
        where T: IComparable
    {
        public string Type { get; }
        public T Value { get; set; }

        public Box(T value)
        {
            Value = value;
            Type = value.GetType().ToString();
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }

        
    }
}

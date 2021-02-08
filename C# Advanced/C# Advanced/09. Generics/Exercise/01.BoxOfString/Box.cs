using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace _01.BoxOfString
{
    public class Box<T>
    {
        public string Type { get;}
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

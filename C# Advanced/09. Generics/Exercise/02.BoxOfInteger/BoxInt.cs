using System;
using System.Collections.Generic;
using System.Text;

namespace _02.BoxOfInteger
{
    public class BoxInt<T>
    {
        public string Type { get; }
        public T Value { get; set; }

        public BoxInt(T value)
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

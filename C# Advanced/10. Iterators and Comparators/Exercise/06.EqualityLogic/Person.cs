using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    class Person: IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            throw new NotImplementedException();
        }
    }
}

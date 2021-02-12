using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Cache;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person: IComparable<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        //&quot;{name} {age} {town}&quot;
        public Person(string name, int age, string town)
        {
            Age = age;
            Name = name;
            Town = town;
        }

        public int CompareTo(Person other)
        {
            if (Name!=other.Name)
            {
                return Name.CompareTo(other.Name);
            }
            if (Age!=other.Age)
            {
                return Age.CompareTo(other.Age);
            }
            if (Town!=other.Town)
            {
                return Town.CompareTo(other.Town);
            }
            return 0;
        }
    }
}

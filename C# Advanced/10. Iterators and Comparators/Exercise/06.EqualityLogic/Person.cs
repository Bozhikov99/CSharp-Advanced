using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.EqualityLogic
{
    class Person: IComparable<Person>
    {

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (GetHashCode()!=other.GetHashCode())
            {
                if (Name!=other.Name)
                {
                    return Name.CompareTo(other.Name);
                }
                else if (Age!=other.Age)
                {
                    return Age.CompareTo(other.Age);
                }
            }
            return 0;
        }
        public override int GetHashCode()
        {
            int nameHash = Name.GetHashCode();
            int ageHash = Age.GetHashCode();
            return nameHash + Age;
        }

        public override bool Equals(object other)
        {
            return GetHashCode().Equals(other.GetHashCode());
        }
    }
}

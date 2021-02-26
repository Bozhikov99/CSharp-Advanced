using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public virtual string ProduceSound()
        {
            return string.Empty;
        }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            return sb.ToString();
        }
    }
}

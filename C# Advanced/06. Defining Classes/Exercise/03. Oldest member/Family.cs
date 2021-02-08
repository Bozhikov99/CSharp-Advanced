using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Members { get; set; } = new List<Person>();

        public void AddMember(Person newMember)
        {
            Members.Add(newMember);
        }

        public string GetOldestMember()
        {
            Person oldestMember = Members.OrderByDescending(m => m.Age).First();
            return $"{oldestMember.Name} {oldestMember.Age}";
        }
    }
}

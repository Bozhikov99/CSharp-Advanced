using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Pet : IBirthable, IPet
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Collection { get; set; } = new List<Pokemon>();

        public Trainer(string name)
        {
            Badges = 0;
            Name = name;
        }
    }
}

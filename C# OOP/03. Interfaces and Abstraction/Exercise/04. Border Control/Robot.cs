using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IRobot
    {
        public Robot(string name, string id)
        {
            Id = id;
            Name = name;
        }
        public string Id { get; set; }
        public string Name { get; set ; }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw() =>"Drawing";
    }
}

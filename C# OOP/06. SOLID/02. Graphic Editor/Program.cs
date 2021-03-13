using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Rectangle(),
                new Circle(),
                new Square()
            };

            foreach (IShape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}

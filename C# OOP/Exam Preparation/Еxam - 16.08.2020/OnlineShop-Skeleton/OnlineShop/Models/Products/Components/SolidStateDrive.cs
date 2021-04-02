using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double performance, int generation)
            : base(id, manufacturer, model, price, performance*1.2, generation)
        {
        }
    }
}

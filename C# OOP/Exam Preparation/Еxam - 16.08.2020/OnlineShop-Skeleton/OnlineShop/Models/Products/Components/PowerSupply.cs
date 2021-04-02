using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        public PowerSupply(int id, string manufacturer, string model, decimal price, double performance, int generation)
            : base(id, manufacturer, model, price, performance*1.05, generation)
        {
        }
    }
}

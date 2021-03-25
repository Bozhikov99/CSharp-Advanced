using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock.Models
{
    public class Product : IProduct
    {
        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo(IProduct other)
        {
            return Price.CompareTo(other.Price);
        }
    }
}

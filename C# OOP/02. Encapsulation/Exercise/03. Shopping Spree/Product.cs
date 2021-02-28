using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
        private string name;
        private decimal cost;
        public decimal Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            bag = new List<Product>();
            Name = name;
            Money = money;
        }
        private string name;
        private decimal money;
        List<Product> bag;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (money-product.Cost < 0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                money -= product.Cost;
                bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bag.Count>0)
            {
            return $"{Name} - {string.Join(", ", bag)}";
            }
            return $"{Name} - Nothing bought";
        }
    }
}

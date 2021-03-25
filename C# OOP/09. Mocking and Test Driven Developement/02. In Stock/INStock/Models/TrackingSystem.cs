using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;

namespace INStock.Models
{
    public class TrackingSystem
    {
        private readonly IList<IProduct> products;

        public int Count { get=>products.Count;}
        public TrackingSystem(IList<IProduct> prods)
        {
            products = prods;
        }

        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public void Add(IProduct product)
        {
            if (products.Any(p=>p.Label==product.Label))
            {
                throw new ArgumentException("Product with such label have already been added!");
            }

            products.Add(product);
        }
        public bool Contains(IProduct product)
        {
            return products.Any(p=>p.Label==product.Label);
        }

        public IProduct Find(int index)
        {
            if (Count<index||index<=0)
            {
                throw new IndexOutOfRangeException("Invalid Index!");
            }

            return products[index-1];
        }

        public IProduct FindByLabel(string label)
        {
            if (!products.Any(p => p.Label == label))
            {
                throw new ArgumentException("Label does not exist!");
            }

            IProduct product = products.First(x => x.Label == label);

            return product;
        }

        public IProduct FindMostExpensiveProducts()
        {
            

            return products.OrderByDescending(p => p.Price).First();
        }

        public List<IProduct> FindAllByPriceRange(decimal min, decimal max)
        {
            List<IProduct> productsInRange = products
                .OrderByDescending(p=>p.Price)
                .Where(p => p.Price >= min && p.Price <= max)
                .ToList();

            return productsInRange;
        }

        public List<IProduct> FindAllByPrice(decimal price)
        {
            List<IProduct> items=products
                .Where(p=>p.Price==price)
                .ToList();

            return items;
        }

        public List<IProduct> FindAllByQuantity(int v)
        {
            List<IProduct> items=products
                .Where(p=>p.Quantity==v)
                .ToList();

            return items;
        }

        public IList<IProduct> GetEnumerator()
        {
            return products;
        }
    }
}

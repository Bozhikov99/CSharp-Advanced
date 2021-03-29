using _03._Command_Pattern.Contracts;
using System;

namespace _03._Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice modifier = new ModifyPrice();
            Product prod = new Product("Phone", 500);

            Execute(prod, modifier, new ProductCommand(prod, PriceAction.Increase, 100));
            Execute(prod, modifier, new ProductCommand(prod, PriceAction.Decrease, 12));
        }

        private static void Execute(Product product, ModifyPrice modifier, ICommand cmd)
        {
            modifier.SetCommand(cmd);
            modifier.Invoke();
        }
    }
}

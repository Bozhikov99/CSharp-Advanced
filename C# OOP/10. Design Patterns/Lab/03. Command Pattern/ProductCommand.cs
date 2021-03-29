using _03._Command_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace _03._Command_Pattern
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;
        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this.priceAction = priceAction;
            this.product = product;
            this.amount = amount;
        }

        public void Execute()
        {
            if (priceAction==PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else
            {
                product.DecreasePrice(amount);
            }
        }
    }
}

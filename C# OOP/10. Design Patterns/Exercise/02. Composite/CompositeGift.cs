using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var item in gifts)
            {
                totalPrice += item.CalculateTotalPrice();
            }

            return totalPrice;
        }

    }
}

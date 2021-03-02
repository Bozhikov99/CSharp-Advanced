using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name, Dough dough)
        {
            Name = name;
            PizzaDough = dough;
            toppings = new List<Topping>();
        }

        private const int minNameLength = 1;
        private const int maxNameLength = 15;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Dough PizzaDough { set => dough = value; }
        public int ToppingCount { get => toppings.Count; }
        public string Name
        {
            get => name;
            set
            {
                Validator.ThrowArgumentException(value, minNameLength, maxNameLength, "Pizza name should be between 1 and 15 symbols.");
                name = value;
            }
        }

        public void AddTopping(Topping current)
        {
            if (ToppingCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                toppings.Add(current);
            }
        }

        public double GetCalories()
        {
            return dough.TotalCalories()+toppings.Sum(c=>c.GetCalories());
        }

        public override string ToString()
        {
            return $"{Name} - {GetCalories():F2} Calories.";
        }
    }
}

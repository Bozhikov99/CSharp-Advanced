using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine()
                .Split()[1];

            string[] doughData = Console.ReadLine()
                .Split();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            int doughWeight = int.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string cmd = Console.ReadLine();
                while (cmd != "END")
                {
                    string[] tokens = cmd.Split();

                    pizza.AddTopping(new Topping(tokens[1], int.Parse(tokens[2])));

                    cmd = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}

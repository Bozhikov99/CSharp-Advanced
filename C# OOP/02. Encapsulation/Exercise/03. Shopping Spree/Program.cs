using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                string[] tok = token.Split('=');
                string name = tok[0].Trim();
                decimal money = decimal.Parse(tok[1].Trim());
                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                string[] tok = token.Split('=');
                string name = tok[0].Trim();
                decimal cost = decimal.Parse(tok[1].Trim());
                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] purchase = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = purchase[0];
                string product = purchase[1];
                Person currentPerson = people.Where(p => p.Name == name).FirstOrDefault();
                Product currentProduct = products.Where(p => p.Name == product).FirstOrDefault();
                if (currentPerson != null && currentProduct != null)
                {
                    currentPerson.BuyProduct(currentProduct);
                }

                cmd = Console.ReadLine();
            }

            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }


        }
    }
}

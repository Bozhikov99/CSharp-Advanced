using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> foods = new Dictionary<int, int>
            {
                {25,0 },
                {50, 0 },
                {75, 0 },
                {100, 0 },
            };

            int[] liquidInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ingredientInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidInput);
            Stack<int> ingredients = new Stack<int>(ingredientInput);


            while (liquids.Count>0&&ingredients.Count>0)
            {
                int sum = ingredients.Peek() + liquids.Dequeue();

                if (foods.ContainsKey(sum))
                {
                    foods[sum]++;                   
                    ingredients.Pop();
                }
                else
                {
                    int newIngredientValue = ingredients.Pop() + 3;
                    ingredients.Push(newIngredientValue);
                    while (!foods.ContainsKey(sum)&&liquids.Count>0&&
                        ingredients.Count>0)
                    {
                        sum = ingredients.Peek() + liquids.Dequeue();
                        newIngredientValue = ingredients.Pop() + 3;
                        ingredients.Push(newIngredientValue);
                        if (foods.ContainsKey(sum))
                        {      
                            foods[sum]++;
                            ingredients.Pop();
                        }
                    }
                }
            }

            string firstLineOutput = foods.All(x => x.Value > 0) ?
                "Wohoo! You succeeded in cooking all the food!" :
                "Ugh, what a pity! You didn't have enough materials to cook everything.";

            string liquidOutput = liquids.Count > 0 ?
                $"{string.Join(", ", liquids)}" :
                "none";
            
            string ingredientOutput = ingredients.Count > 0 ?
                $"{string.Join(", ", ingredients)}" :
                "none";


            Console.WriteLine(firstLineOutput);
            Console.WriteLine($"Liquids left: {liquidOutput}");
            Console.WriteLine($"Ingredients left: {ingredientOutput}");
            Console.WriteLine($"Bread: {foods[25]}");
            Console.WriteLine($"Cake: {foods[50]}");
            Console.WriteLine($"Fruit Pie: {foods[100]}");
            Console.WriteLine($"Pastry: {foods[75]}");
        }
    }
}

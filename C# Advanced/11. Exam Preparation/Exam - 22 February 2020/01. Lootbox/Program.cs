using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>();

            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (firstBox.Any() && secondBox.Any())
            {
                int sum = firstBox.Peek() + secondBox.Peek();

                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            string boxOutput = secondBox.Count == 0 ? "Second lootbox is empty" :
                "First lootbox is empty";

            string sumOutput = collection.Sum() >= 100 ? "Your loot was epic!" :
                "Your loot was poor...";
            Console.WriteLine(boxOutput);
            Console.WriteLine($"{sumOutput} Value: {collection.Sum()}");
        }
    }
}

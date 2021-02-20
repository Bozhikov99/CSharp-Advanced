using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<int, int> bombs = new Dictionary<int, int>()
            {
                { 60, 0 },
                { 40, 0 },
                {120, 0 }
            };

            while (!bombs.All(b=>b.Value>=3)&&
                casings.Any()&&
                effects.Any())
            {
                if (bombs.ContainsKey(casings.Peek()+effects.Peek()))
                {
                    bombs[casings.Pop() + effects.Dequeue()]++;
                }
                else
                {
                    while (casings.Any()&&
                        effects.Any())
                    {
                        int reducedCasing = casings.Pop() - 5;
                        casings.Push(reducedCasing);

                        if (bombs.ContainsKey(casings.Peek() + effects.Peek()))
                        {
                            bombs[casings.Pop() + effects.Dequeue()]++;
                            break;
                        }
                    }
                }
            }

            string firstLine = bombs.All(b => b.Value >= 3) ? "Bene! You have successfully filled the bomb pouch!" :
                "You don't have enough materials to fill the bomb pouch.";

            string effectsLine = effects.Any() ? $"{string.Join(", ", effects)}":
                "empty";

            string casingsLine = casings.Any() ? $"{string.Join(", ", casings)}" :
                "empty";

            Console.WriteLine(firstLine);
            Console.WriteLine($"Bomb Effects: {effectsLine}");
            Console.WriteLine($"Bomb Casings: {casingsLine}");
            Console.WriteLine($"Cherry Bombs: {bombs[60]}");
            Console.WriteLine($"Datura Bombs: {bombs[40]}");
            Console.WriteLine($"Smoke Decoy Bombs: {bombs[120]}");
        }
    }
}

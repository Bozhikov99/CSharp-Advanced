using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barellSize = int.Parse(Console.ReadLine());
            int[] bulletInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligencePrice = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(bulletInput);
            Queue<int> locks = new Queue<int>(locksInput);

            int bulletsShot = 0;
            int currentBarell = barellSize;
            while (locks.Any()&&bullets.Any())
            {
                
                if (bullets.Pop()<=locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                currentBarell--;
                bulletsShot++;
                if (currentBarell == 0 && bullets.Any())
                {
                    currentBarell = barellSize;
                    Console.WriteLine("Reloading!");
                }
            }
            if (!locks.Any())
            {
                intelligencePrice -= bulletPrice * bulletsShot;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligencePrice}");
            }
            else 
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}

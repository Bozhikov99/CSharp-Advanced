using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> box = new Stack<int>(clothes);
            int count = 0;
            int currentRack = 0;
            while (box.Count>0)
            {
                if (currentRack+box.Peek()<=rackCapacity)
                {
                    currentRack += box.Pop();
                }
                else
                {
                    count++;
                    currentRack = box.Pop();
                }
            }
            count++;
            Console.WriteLine(count);
        }
    }
}

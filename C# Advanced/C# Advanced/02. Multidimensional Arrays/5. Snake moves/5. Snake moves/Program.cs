using System;
using System.Linq;

namespace _5._Snake_moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[,] isle = new int[dimensions[0], dimensions[1]];

                
        }
    }
}

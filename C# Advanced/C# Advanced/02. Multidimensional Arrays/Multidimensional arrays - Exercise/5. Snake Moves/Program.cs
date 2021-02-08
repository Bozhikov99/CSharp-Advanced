using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            char[,] stairs = new char[dimensions[0], dimensions[1]];

            int snakeCounter = 0;
            for (int rows = 0; rows < stairs.GetLength(0); rows++)
            {
                for (int cols = 0; cols < stairs.GetLength(1); cols++)
                { 
                    if (rows%2!=0)
                    {
                        stairs[rows, stairs.GetLength(1)-1-cols] = snake[snakeCounter];
                    }
                    else
                    {
                        stairs[rows, cols] = snake[snakeCounter];
                    }
                    snakeCounter++;
                    if (snakeCounter==snake.Length)
                    {
                        snakeCounter = 0;
                    }
                    GC.Collect();
                }
            }
            for (int rows = 0; rows < stairs.GetLength(0); rows++)
            {
                for (int cols = 0; cols < stairs.GetLength(1); cols++)
                {
                    Console.Write($"{stairs[rows,cols]}");
                }
                Console.WriteLine();
            }
        }
    }
}

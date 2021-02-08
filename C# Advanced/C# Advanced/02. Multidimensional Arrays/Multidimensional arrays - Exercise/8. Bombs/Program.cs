using System;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];
            int aliveCount = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string[] bombsCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string coordinates in bombsCoordinates)
            {
                int x = int.Parse(coordinates.Split(",", StringSplitOptions.RemoveEmptyEntries)[0]);
                int y = int.Parse(coordinates.Split(",", StringSplitOptions.RemoveEmptyEntries)[1]);
                int bombValue = matrix[x][y];
                if (bombValue > 0)
                {
                    matrix[x][y] = 0;
                    if (isValidCell(matrix, x - 1, y - 1))
                    {
                        matrix[x - 1][y - 1] -= bombValue;
                    }
                    if (isValidCell(matrix, x - 1, y))
                    {
                        matrix[x - 1][y] -= bombValue;
                    }
                    if (isValidCell(matrix, x - 1, y + 1))
                    {
                        matrix[x - 1][y + 1] -= bombValue;
                    }
                    if (isValidCell(matrix, x, y - 1))
                    {
                        matrix[x][y - 1] -= bombValue;
                    }
                    if (isValidCell(matrix, x, y + 1))
                    {
                        matrix[x][y + 1] -= bombValue;
                    }
                    if (isValidCell(matrix, x + 1, y - 1))
                    {
                        matrix[x + 1][y - 1] -= bombValue;
                    }
                    if (isValidCell(matrix, x + 1, y))
                    {
                        matrix[x + 1][y] -= bombValue;
                    }
                    if (isValidCell(matrix, x + 1, y + 1))
                    {
                        matrix[x + 1][y + 1] -= bombValue;
                    }
                }

            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row][col]>0)
                    {
                        aliveCount++;
                        sum += matrix[row][col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {sum}");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join(" ",matrix[i]));
            }
        }

        public static bool isValidCell(int[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length &&
                col >= 0 && col < matrix[0].Length&&
                matrix[row][col]>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

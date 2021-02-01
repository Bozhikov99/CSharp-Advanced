using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];
            for (int rows = 0; rows < size[0]; rows++)
            {
                int[] currentRow = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                }
            }
            int max = 0;
            int[,] subMatrix = new int[3, 3];
            for (int i = 0; i < size[0] - 2; i++)
            {
                int currentSum = 0;
                for (int k = 0; k < size[1] - 2; k++)
                {
                    currentSum += matrix[i, k] + matrix[i, k+1] + matrix[i , k+2] +
                        matrix[i+1, k ] + matrix[i+1, k + 1] + matrix[i+1, k+2] +
                        matrix[i + 2, k] + matrix[i + 2, k + 1] + matrix[i + 2, k + 2];
                    if (currentSum>max)
                    {
                        subMatrix[0, 0] = matrix[i, k];
                        subMatrix[0, 1] = matrix[i, k+1];
                        subMatrix[0, 2] = matrix[i, k+2];
                        subMatrix[1, 0] = matrix[i+1, k];
                        subMatrix[1, 1] = matrix[i+1, k+1];
                        subMatrix[1, 2] = matrix[i+1, k+2];
                        subMatrix[2, 0] = matrix[i+2, k];
                        subMatrix[2, 1] = matrix[i+2, k+1];
                        subMatrix[2, 2] = matrix[i+2, k+2];
                        max = currentSum;
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine($"Sum = {max}");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{subMatrix[i,0]} {subMatrix[i, 1]} {subMatrix[i, 2]}");
            }
            
        }
    }
}

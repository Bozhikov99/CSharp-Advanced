using System;
using System.Linq;
using System.Security.Cryptography;

namespace _5._Square_with_Maximum_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int rows = 0; rows < matrixSize[0]; rows++)
            {
                int[] row = Console.ReadLine()
                    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrixSize[1]; columns++)
                {
                    matrix[rows, columns] = row[columns];
                }
            }
            int biggest = 0;
            int[,] subMatrix = new int[2, 2];
            for (int rows = 0; rows < matrixSize[0]-1; rows++)
            {
                int currentSum = 0;
                for (int columns = 0; columns < matrixSize[1]-1; columns++)
                {
                    currentSum += matrix[rows, columns] + matrix[rows, columns + 1] + matrix[rows + 1, columns]+matrix[rows+1,columns+1];
                    if (currentSum>biggest)
                    {
                        biggest = currentSum;
                        subMatrix[0, 0] = matrix[rows, columns];
                        subMatrix[0, 1] = matrix[rows, columns+1];
                        subMatrix[1, 0] = matrix[rows+1, columns];
                        subMatrix[1, 1] = matrix[rows+1, columns+1];
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine($"{subMatrix[0, 0]} {subMatrix[0, 1]}");
            Console.WriteLine($"{subMatrix[1, 0]} {subMatrix[1, 1]}");
            Console.WriteLine(biggest);
        }
    }
}

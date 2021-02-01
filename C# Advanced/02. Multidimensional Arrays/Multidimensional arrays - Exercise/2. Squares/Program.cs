using System;
using System.Linq;

namespace _2._Squares
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];
            int count = 0;
            for (int rows = 0; rows < size[0]; rows++)
            {
                string[] current = Console.ReadLine()
                    .Split();
                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows, cols] = current[cols];
                }
            }

            for (int i = 0; i < size[0] - 1; i++)
            {
                for (int k = 0; k < size[1] - 1; k++)
                {
                    bool isSquare = matrix[i, k] == matrix[i, k + 1] && matrix[i, k] == matrix[i + 1, k] &&
                        matrix[i, k] == matrix[i + 1, k + 1];
                    if (isSquare)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}

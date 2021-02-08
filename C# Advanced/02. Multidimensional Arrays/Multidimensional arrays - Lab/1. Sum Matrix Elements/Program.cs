using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int columns = size[1];
            int[,] matrix = new int[rows, columns];
            int sum = 0;
            for (int r = 0; r < rows; r++)
            {
                int[] row= Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int c = 0; c < columns; c++)
                {
                    matrix[r, c] = row[c];
                    sum += matrix[r, c];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] square = new int[n, n];
            int sum = 0;

            for (int rows = 0; rows < n; rows++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < n; columns++)
                {
                    square[rows, columns] = currentRow[columns];
                }
            }

            for (int i = 0; i < n; i++)
            {
                sum += square[i, i];
            }
            Console.WriteLine(sum);
        }
    }
}

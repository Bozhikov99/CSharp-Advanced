using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            //blooming
            string cmd = Console.ReadLine();
            while (cmd != "Bloom Bloom Plow")
            {
                int row = int.Parse(cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
                int col = int.Parse(cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                if (!isValidCoord(row, col, matrix))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int rows = 0; rows < n; rows++)
                    {
                        matrix[rows, col]++;
                    }
                    for (int cols = 0; cols < m; cols++)
                    {
                        if (cols==col)
                        {
                            continue;
                        }
                        matrix[row, cols]++;
                    }
                }

                cmd = Console.ReadLine();
            }

            //output
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < m; cols++)
                {
                    Console.Write($"{matrix[rows, cols]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool isValidCoord(int row, int col, int[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}

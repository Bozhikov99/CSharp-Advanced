using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int rows = 0; rows < matrix.Length-1; rows++)
            {
                if (matrix[rows].Length==matrix[rows+1].Length)
                {
                    matrix[rows] = matrix[rows].Select(e => e *= 2).ToArray();
                    matrix[rows+1] = matrix[rows+1].Select(e => e *= 2).ToArray();
                }
                else
                {
                    matrix[rows] = matrix[rows].Select(e => e /= 2).ToArray();
                    matrix[rows+1] = matrix[rows+1].Select(e => e /= 2).ToArray();
                }
            }

            string[] cmd = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0]!="End")
            {
                string command = cmd[0];
                int x = int.Parse(cmd[1]);
                int y = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                if (x>=0&&x<matrix.Count())
                {
                    if (y>=0&&y<matrix[x].Length)
                    {
                        if (command == "Add")
                        {
                            matrix[x][y] += value;
                        }
                        else if (command == "Subtract")
                        {
                            matrix[x][y] -= value;
                        }
                    }
                }
                cmd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}

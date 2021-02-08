using System;
using System.Buffers;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];
            for (int rows = 0; rows < dimensions[0]; rows++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split();

                for (int cols = 0; cols < dimensions[1]; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                }
            }
            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                //swap 0 0 1 1
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool isInvalid = tokens.Length != 5 ||
                    int.Parse(tokens[1]) < 0 || int.Parse(tokens[1]) >=matrix.GetLength(0) ||
                    int.Parse(tokens[2]) < 0 || int.Parse(tokens[2]) >= matrix.GetLength(1) ||
                    int.Parse(tokens[3]) < 0 || int.Parse(tokens[3]) >= matrix.GetLength(0) ||
                    int.Parse(tokens[4]) < 0 || int.Parse(tokens[4]) >= matrix.GetLength(1)  ;
                if (isInvalid == false&&tokens[0]=="swap")
                {
                    string swappedString = matrix[int.Parse(tokens[1]),int.Parse(tokens[2])];

                    matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = matrix[int.Parse(tokens[3]), int.Parse(tokens[4])];
                    matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = swappedString;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                cmd = Console.ReadLine();
            }    
        }
    }
}

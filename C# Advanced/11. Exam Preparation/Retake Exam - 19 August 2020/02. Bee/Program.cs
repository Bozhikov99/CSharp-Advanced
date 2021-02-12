using System;
using System.Linq;
using System.Numerics;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int beeCol = 0;
            int beeRow = 0;
            int count = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'B')
                    {
                        beeCol = col;
                        beeRow = row;
                    }
                }
            }

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                matrix[beeRow, beeCol] = '.';
                beeRow=MoveRow(beeRow, cmd);
                beeCol=MoveCol(beeCol, cmd);
                if (!ValidatePosition(beeRow, beeCol, matrix))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (matrix[beeRow, beeCol]=='O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, cmd);
                    beeCol = MoveCol(beeCol, cmd);
                    if (!ValidatePosition(beeRow, beeCol, matrix))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }
                if (matrix[beeRow, beeCol]=='f')
                {
                    count++;
                }

                matrix[beeRow, beeCol] = 'B';
                cmd = Console.ReadLine();
            }

            string output = count >= 5 ? $"Great job, the bee managed to pollinate {count} flowers!" :
                $"The bee couldn't pollinate the flowers, she needed {5 - count} flowers more";

            Console.WriteLine(output);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static bool ValidatePosition(int row, int col, char[,] matrix)
        {
            if (row<0||row>=matrix.GetLength(0)||
                col<0||col>=matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
        public static int MoveRow(int row, string input)
        {
            switch (input)
            {
                
                case "up":
                    row--;
                    break;

                case "down":
                    row++;
                    break;

                default:
                    break;
            }
            return row;
        }
        public static int MoveCol(int col, string input)
        {
            switch (input)
            {

                case "left":
                    col--;
                    break;

                case "right":
                    col++;
                    break;


                default:
                    break;
            }
            return col;
        }


    }
}

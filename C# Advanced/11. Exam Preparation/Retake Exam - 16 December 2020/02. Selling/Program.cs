using System;
using System.Linq;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            int money = 0;
            string output = string.Empty;

            for (int rows = 0; rows < n; rows++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                for (int cols = 0; cols < n; cols++)
                {
                    if (currentRow[cols] == 'S')
                    {
                        playerRow = rows;
                        playerCol = cols;
                    }
                    
                    matrix[rows, cols] = currentRow[cols];
                }
            }

            string cmd = Console.ReadLine();
            while (money < 50)
            {
                matrix[playerRow, playerCol] = '-';
                switch (cmd)
                {
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    default:
                        break;
                }

                if (!ValidatePosition(playerRow, playerCol, matrix))
                {
                    break;
                }
                
                if (matrix[playerRow,playerCol]=='O')
                {
                    matrix[playerRow, playerCol] = '-';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row,col]=='O')
                            {
                                playerRow = row;
                                playerCol = col;
                            }
                        }
                    }
                }

                else if (char.IsDigit(matrix[playerRow, playerCol]))
                {
                    money += int.Parse(matrix[playerRow, playerCol].ToString());
                }

                matrix[playerRow, playerCol] = 'S';
                cmd = Console.ReadLine();
            }

            output = money < 50 ? "Bad news, you are out of the bakery.":
                "Good news! You succeeded in collecting enough money!";

            Console.WriteLine(output);
            Console.WriteLine($"Money: {money}");

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write($"{matrix[rows,cols]}");
                }
                Console.WriteLine();
            }
        }

        public static bool ValidatePosition(int playerRow, int playerCol, char[,] matrix)
        {
            if (playerRow < 0|| playerRow >= matrix.GetLength(0)||
               playerCol < 0|| playerCol >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}

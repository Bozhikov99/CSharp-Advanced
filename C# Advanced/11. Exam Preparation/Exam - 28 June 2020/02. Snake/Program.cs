using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;
            int foodCount = 0;

            int[] firstBurrow = { -1, -1 };
            int[] secondBurrow = { -1, -1 };
            bool burrowTrigger = false;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        snakeCol = col;
                        snakeRow = row;
                    }
                    else if (currentRow[col] == 'B')
                    {
                        if (burrowTrigger)
                        {
                            secondBurrow[0] = row;
                            secondBurrow[1] = col;
                        }
                        else
                        {
                            firstBurrow[0] = row;
                            firstBurrow[1] = col;
                            burrowTrigger = true;
                        }
                    }
                    matrix[row, col] = currentRow[col];
                }
            }

            while (foodCount < 10)
            {
                string cmd = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';

                switch (cmd)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                    default:
                        break;
                }

                if (!ValidatePosition(matrix, snakeRow, snakeCol))
                {
                    break;
                }
                else
                {
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;
                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                            matrix[snakeRow, snakeCol] = '.';
                        if (snakeRow == firstBurrow[0] && snakeCol == firstBurrow[1])
                        {
                            snakeRow = secondBurrow[0];
                            snakeCol = secondBurrow[1];
                        }
                        else
                        {
                            snakeRow = firstBurrow[0];
                            snakeCol = firstBurrow[1];
                        }
                    }
                }
                matrix[snakeRow, snakeCol] = 'S';
            }
            string firstLineOutput = foodCount < 10 ? "Game over!" : "You won! You fed the snake.";
            Console.WriteLine(firstLineOutput);
            Console.WriteLine($"Food eaten: {foodCount}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        public static bool ValidatePosition(char[,] matrix, int snakeRow, int snakeCol)
        {
            if (snakeRow < 0 || snakeRow >= matrix.GetLength(0) ||
                snakeCol < 0 || snakeCol >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}

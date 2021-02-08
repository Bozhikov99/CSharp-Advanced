using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._A_game_of_knights
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[][] board = new char[matrixSize][];
            int removeCount = 0;
            int maxRow = 0;
            int maxCol = 0;
            //loading the board
            for (int rows = 0; rows < matrixSize; rows++)
            {
                board[rows] = Console.ReadLine().ToCharArray();
            }

            while (true)
            {

                int maxThreat = 0;
                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board.Length; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            int currentThreat = 0;
                            //horizontal up left
                            if (Check(board, row - 1, col - 2))
                            {
                                currentThreat++;
                            }
                            //horizontal up right
                            if (Check(board, row - 1, col + 2))
                            {
                                currentThreat++;
                            }
                            //horizontal down left
                            if (Check(board, row + 1, col - 2))
                            {
                                currentThreat++;
                            }
                            //horizontal down right
                            if (Check(board, row + 1, col + 2))
                            {
                                currentThreat++;
                            }
                            if (Check(board, row - 2, col - 1))
                            {
                                currentThreat++;
                            }
                            if (Check(board, row - 2, col + 1))
                            {
                                currentThreat++;
                            }
                            if (Check(board, row + 2, col - 1))
                            {
                                currentThreat++;
                            }
                            if (Check(board, row + 2, col + 1))
                            {
                                currentThreat++;
                            }
                            if (currentThreat > maxThreat)
                            {
                                maxThreat = currentThreat;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if (maxThreat > 0)
                {
                    board[maxRow][maxCol] = '0';
                    removeCount++;
                }
                else
                {
                    Console.WriteLine(removeCount);
                    break;
                }
            }
        }

        public static bool Check(char[][] Matrix, int row, int col)
        {
            if (row >= 0 && row < Matrix.Length && col >= 0 && col < Matrix[0].Length)
            {
                if (Matrix[row][col] == 'K')
                {
                    return true;
                }

            }
            return false;
        }

    }
}

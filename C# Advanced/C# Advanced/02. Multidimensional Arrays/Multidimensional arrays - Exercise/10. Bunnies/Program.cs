using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _10._Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] lair = new char[dimensions[0],dimensions[1]];

            int playerRow = 0;
            int playerCol = 0;

            bool isDead = false;
            bool isWon = false;
            string output = string.Empty;

            for (int i = 0; i < dimensions[0]; i++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();
                for (int cols = 0; cols < dimensions[1]; cols++)
                {
                    lair[i, cols] = currentRow[cols];
                    if (currentRow[cols]=='P')
                    {
                        playerCol = cols;
                        playerRow = i;
                    }
                }
            }

            string commands = Console.ReadLine();

            foreach (char cmd in commands)
            {
                switch (cmd)
                {
                    case 'U':
                        lair[playerRow, playerCol] = '.';
                        if (isValidCell(lair, playerRow-1,playerCol))
                        {
                            playerRow--;
                        }
                        else
                        {
                            isWon = true;
                        }
                        break;
                    case 'D':
                        lair[playerRow, playerCol] = '.';
                        if (isValidCell(lair, playerRow+1,playerCol))
                        {
                            playerRow++;
                        }
                        else
                        {
                            isWon = true;
                        }
                        break;
                    case 'L':
                        lair[playerRow, playerCol] = '.';
                        if (isValidCell(lair, playerRow,playerCol-1))
                        {     
                            playerCol--;
                        }
                        else
                        {
                            isWon = true;
                        }
                        break;
                    case 'R':
                        lair[playerRow, playerCol] = '.';
                        if (isValidCell(lair, playerRow,playerCol+1))
                        {
                            playerCol++;
                        }
                        else
                        {
                            isWon = true;
                        }
                        break;
                    
                    default:
                        break;
                }
                
                if (!isWon&&lair[playerRow, playerCol] != 'B')
                {
                    lair[playerRow, playerCol] = 'P';
                }
                else
                {
                    isDead = true;
                }
                //populate
                List<int[]> coordinates = new List<int[]>();
                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            if (isValidCell(lair, row + 1, col))
                            {
                                if (lair[row + 1, col] == 'P')
                                {
                                    isDead = true;
                                }
                                coordinates.Add(new int[] { row + 1, col });
                            }
                            if (isValidCell(lair, row - 1, col))
                            {
                                if (lair[row - 1, col] == 'P')
                                {
                                    isDead = true;
                                }
                                coordinates.Add(new int[] { row - 1, col });
                            }
                            if (isValidCell(lair, row, col+1))
                            {
                                if (lair[row, col+1] == 'P')
                                {
                                    isDead = true;
                                }
                                coordinates.Add(new int[] { row, col +1});
                            }
                            if (isValidCell(lair, row, col-1))
                            {
                                if (lair[row, col-1] == 'P')
                                {
                                    isDead = true;
                                }
                                coordinates.Add(new int[] { row, col -1 });
                            }
                        }
                    }
                }
                foreach (var currentCoordinates in coordinates)
                {
                    lair[currentCoordinates[0], currentCoordinates[1]] = 'B';
                }
                coordinates.Clear();
                if (isWon||isDead)
                {
                    break;
                }
            }
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int k = 0; k < lair.GetLength(1); k++)
                {
                    Console.Write($"{lair[i,k]}");
                }
                Console.WriteLine();
            }
            if (isWon)
            {
                output = "won";
            }
            else
            {
                output = "dead";
            }
            Console.WriteLine($"{output}: {playerRow} {playerCol}");
        }

        public static bool isValidCell(char[,] lair, int row, int col)
        {
            if (row>=0&&row<lair.GetLength(0)&&
                col>=0&&col<lair.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


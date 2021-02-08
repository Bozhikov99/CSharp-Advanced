using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            string[] cmd = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int currentRow = 0;
            int currentCol = 0;
            int totalCoals = 0;
            int coalsCollected = 0;
            string output = string.Empty;

            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int k = 0; k < size; k++)
                {
                    field[i, k] = row[k];
                    if (row[k]=='c')
                    {
                        totalCoals++;
                    }
                    if (row[k]=='s')
                    {
                        currentCol = k;
                        currentRow = i;
                    }
                }
            }

            foreach (string command in cmd)
            {
                switch (command)
                {
                    case "up":
                        if (isValidPosition(field, currentRow-1,currentCol))
                        {
                            currentRow--;
                        }
                        break;
                    case "down":
                        if (isValidPosition(field, currentRow+1,currentCol))
                        {
                            currentRow++;
                        }
                        break;
                    case "left":
                        if (isValidPosition(field, currentRow,currentCol-1))
                        {
                            currentCol--;
                        }
                        break;
                    case "right":
                        if (isValidPosition(field, currentRow,currentCol+1))
                        {
                            currentCol++;
                        }
                        break;
                    default:
                        break;
                }
                if (field[currentRow, currentCol] == 'c')
                {
                    field[currentRow, currentCol] = '*';
                    coalsCollected++;
                    totalCoals--;
                    if (totalCoals==0)
                    {
                        output = $"You collected all coals! ({currentRow}, {currentCol})";
                        break;
                    }
                }
                else if (field[currentRow, currentCol] == 'e')
                {
                    output = $"Game over! ({currentRow}, {currentCol})";
                    break;
                }
            }
            if (output=="")
            {
                output = $"{totalCoals} coals left. ({currentRow}, {currentCol})";
            }
            Console.WriteLine(output);
        }

        public static bool isValidPosition(char[,] field, int row, int col)
        {
            if (row>=0&&col>=0&&row<field.GetLength(0)&&col<field.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}

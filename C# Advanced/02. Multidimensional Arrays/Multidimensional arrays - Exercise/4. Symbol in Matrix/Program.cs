using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] square = new char[n, n];
            int targetRow = 0;
            int targetColumn = 0;
            bool isFound = false;
            for (int rows = 0; rows < n; rows++)
            {
                string currentRow = Console.ReadLine();

                for (int columns = 0; columns < n; columns++)
                {
                    square[rows, columns] = currentRow[columns];
                }
            }
            char targetSymbol = char.Parse(Console.ReadLine());
            for (int rows = 0; rows < n; rows++)
            {
                for (int columns = 0; columns < n; columns++)
                {
                    if (square[rows, columns]==targetSymbol)
                    {
                        isFound = true;
                        targetRow = rows;
                        targetColumn = columns;
                        break;
                    };
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine($"({targetRow}, {targetColumn})");
            }
            else
            {
                Console.WriteLine($"{targetSymbol} does not occur in the matrix");
            }
        }
    }
}

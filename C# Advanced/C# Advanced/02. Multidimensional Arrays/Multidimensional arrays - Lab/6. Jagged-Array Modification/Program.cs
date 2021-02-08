using System;
using System.Data;
using System.Linq;
using System.Threading;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jackedArray = new int[n][];
            for (int arrays = 0; arrays < n; arrays++)
            {
                int[] currentArray = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                jackedArray[arrays] = currentArray;
            }

            string cmd = Console.ReadLine();
            while (cmd!="END")
            {
                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                
                if (row < jackedArray.Length&&row>=0)
                {
                    if (col < jackedArray[row].Length&&col>=0)
                    {
                        switch (tokens[0])
                        {
                            case "Add":
                                jackedArray[row][col] += value;
                                break;
                            case "Subtract":
                                jackedArray[row][col] -= value;
                                break;
                            default:
                                break;
                        }
                                               
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                cmd = Console.ReadLine();
            }
            foreach (var arr in jackedArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}

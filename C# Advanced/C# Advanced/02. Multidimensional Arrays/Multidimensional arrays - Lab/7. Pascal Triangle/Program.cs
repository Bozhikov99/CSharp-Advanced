using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];
            for (int i = 0; i < n; i++)
            {
                pascalTriangle[i] = new long[i+1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length - 1] = 1;
                for (int cols = 1; cols <= pascalTriangle[i].Length-2; cols++)
                {
                    pascalTriangle[i][cols] = pascalTriangle[i - 1][cols] + pascalTriangle[i - 1][cols - 1];
                }
                Console.WriteLine(string.Join(" ",pascalTriangle[i]));
            }
        }
    }

}

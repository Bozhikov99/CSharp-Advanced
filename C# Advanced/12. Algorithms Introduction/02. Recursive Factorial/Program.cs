using System;

namespace _02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecursiveFactorial(int.Parse(Console.ReadLine()),1));
        }

        public static int RecursiveFactorial(int n, int start)
        {
            if (start==n)
            {
                return n;
            }
            return start * RecursiveFactorial(n, ++start);
        }
    }
}

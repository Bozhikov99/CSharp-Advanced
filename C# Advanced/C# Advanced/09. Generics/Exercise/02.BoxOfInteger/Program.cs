using System;

namespace _02.BoxOfInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new BoxInt<int>(int.Parse(Console.ReadLine())).ToString());
            }
        }
    }
}

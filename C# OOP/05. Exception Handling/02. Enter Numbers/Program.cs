using System;

namespace _02._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 15;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine($"Enter {i+1}:");
                    EnterNumber(start, end);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number");
                    i = -1;
                }
            }
        }

        public static void EnterNumber(int start, int end)
        {
            int current = int.Parse(Console.ReadLine());

            if (current<start||current>end)
            {
                throw new ArgumentException();
            }
        }
    }
}

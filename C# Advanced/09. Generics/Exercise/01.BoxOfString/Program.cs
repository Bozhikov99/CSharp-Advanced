using System;

namespace _01.BoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new Box<string>(Console.ReadLine().ToString()));
            }
        }
    }
}

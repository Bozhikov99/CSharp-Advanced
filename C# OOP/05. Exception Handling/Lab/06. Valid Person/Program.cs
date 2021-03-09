using System;

namespace _06._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                
                string[] cmd = Console.ReadLine()
                                    .Split(' ');

                try
                {
                    Person person = new Person(cmd[0], cmd[1], int.Parse(cmd[2]));
                }
                catch (ArgumentOutOfRangeException x)
                {
                    Console.WriteLine(x.Message);
                }
                catch (ArgumentNullException x)
                {
                    Console.WriteLine(x.Message);
                }
            }

        }
    }
}

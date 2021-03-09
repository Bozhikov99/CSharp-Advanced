using System;

namespace SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number<0)
                {
                    throw new InvalidOperationException();
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (Exception x)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}

using System;
using System.Numerics;

namespace _05._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
			BigInteger big = BigInteger.Pow(10, 50);

			try
			{
				double a = Convert.ToDouble(big);
			}
			catch (FormatException)
			{
				Console.WriteLine("The input isn't a number!");
				throw;
			}
			catch (InvalidCastException)
			{
				Console.WriteLine("The input cannot be parsed to 'double'!");
				throw;
			}
			catch (OverflowException)
			{
				Console.WriteLine($"The input number should be between {double.MinValue} and {double.MaxValue}!");
				throw;
			}
			
        }
    }
}

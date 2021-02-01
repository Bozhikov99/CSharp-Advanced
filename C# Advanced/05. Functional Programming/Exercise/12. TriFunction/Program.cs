using System;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> nameCalculate = (n, y) =>
             {
                 int sum = 0;
                 foreach (char x in n)
                 {
                     sum += x;
                 }
                 return sum>=y?true:false;
             };

            Func<string[], Func<string, int, bool>, string> searchName = (arr, function) =>
             {
                 foreach (var name in arr)
                 {
                     if (function(name, n))
                     {
                         return name;
                     }
                 }
                 return null;
             };

            Console.WriteLine(searchName(names, nameCalculate));
        }
    }
}

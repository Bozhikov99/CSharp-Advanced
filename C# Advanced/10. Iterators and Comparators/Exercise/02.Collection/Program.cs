using System;
using System.Linq;
using System.Threading;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] create = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            ListyIterator<string> iterator = new ListyIterator<string>(create);

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {

                switch (cmd)
                {
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Invalid Operation!");
                        }
                        break;
                    case "PrintAll":
                        foreach (string s in iterator)
                        {
                            Console.Write($"{s} ");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}

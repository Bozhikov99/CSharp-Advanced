using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            string cmd = Console.ReadLine();

            while (cmd!="END")
            {
                string[] commands = cmd.Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Push":
                        stack.Push(commands.Skip(1).Select(int.Parse).ToArray());
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No elements");
                        }
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }
                foreach (int n in stack)
                {
                    Console.WriteLine(n);
                }

                Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}

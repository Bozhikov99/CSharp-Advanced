using System;
using System.Collections.Generic;

namespace _6._Songs_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries);
            Queue<string> playlist = new Queue<string>(songs);
            while (playlist.Count>0)
            {
                string cmd = Console.ReadLine();
                string command = cmd.Substring(0, 4).TrimEnd();
                switch (command)
                {
                    case "Play":
                        playlist.Dequeue();
                        break;
                    case "Add":
                        if (playlist.Contains(cmd.Substring(4)))
                        {
                            Console.WriteLine($"{cmd.Substring(4)} is already contained!");
                        }
                        else
                        {
                            playlist.Enqueue(cmd.Substring(4));
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",playlist));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}

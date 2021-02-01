using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace _10._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            int count = 0;
            Queue<string> carsWaiting = new Queue<string>();
            string cmd = Console.ReadLine();
            bool accident = false;
            char hit=' ';
            while (cmd != "END")
            {
                if (cmd=="green")
                {
                    int time = green + window;
                    while (carsWaiting.Any()&&time>window)
                    {
                        if (carsWaiting.Peek().Length<=time)
                        {
                            time -= carsWaiting.Dequeue().Length;
                            count++;
                        }
                        else
                        {
                            string hitCar = carsWaiting.Peek();
                            accident = true;
                            hit = hitCar[time];
                            break;
                        }
                    }
                }
                else
                {
                    carsWaiting.Enqueue(cmd);
                }
                if (accident==true)
                {
                    break;
                }
                cmd = Console.ReadLine();
            }
            if (accident==true)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{carsWaiting.Dequeue()} was hit at {hit}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }
           
        }
    }
}

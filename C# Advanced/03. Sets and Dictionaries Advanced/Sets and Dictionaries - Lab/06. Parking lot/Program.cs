using System;
using System.Collections.Generic;

namespace _06._Parking_lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string[] cmd = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (cmd[0]!="END")
            {
                if (cmd[0]=="IN")
                {
                    parking.Add(cmd[1]);
                }
                else
                {
                    parking.Remove(cmd[1]);
                }
                cmd = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (parking.Count>0)
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

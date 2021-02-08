using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Softuni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();
            string cmd = Console.ReadLine();

            while (cmd!="PARTY")
            {
                if (cmd=="PARTY")
                {  
                    break;
                }
                else
                {
                    if (char.IsDigit(cmd.First()))
                    {
                        vip.Add(cmd);
                    }
                    else
                    {
                        regular.Add(cmd);
                    }
                }
                cmd = Console.ReadLine();
            }

            while (cmd!="END")
            {
                if (char.IsDigit(cmd.First()))
                {
                    vip.Remove(cmd);
                }
                else
                {
                    regular.Remove(cmd);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine(vip.Count+regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt"))
            {
                using (StreamWriter writer=new StreamWriter("../../../Output.txt"))
                {
                    int i = 1;
                    string current = reader.ReadLine();
                    while (current!=null)
                    {
                        writer.WriteLine($"{i}. {current}");
                        i++;
                        current = reader.ReadLine();
                    }
                }
            }
        }
    }
}

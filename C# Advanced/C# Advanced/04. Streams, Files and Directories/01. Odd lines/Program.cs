using System;
using System.IO;

namespace _01._Odd_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                int i = 0;
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    

                    while (currentLine != null)
                    {
                        if (i % 2 == 0)
                        {
                            writer.WriteLine(currentLine);
                        }
                        currentLine = reader.ReadLine();
                        i++;

                    }
                }
            }
        }
    }
}

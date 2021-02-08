using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Even_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../text.txt"))
            {
                using (StreamWriter write = new StreamWriter("../../../../output.txt"))
                {

                    int lineCount = 0;
                    string current = reader.ReadLine();
                    string pattern = @"[-,.!?]";
                    while (current != null)
                    {
                        if (lineCount++ % 2 == 0)
                        {
                            string edited = Regex.Replace(current, pattern, "@");
                            string[] words = edited.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                            write.WriteLine(string.Join(" ", words.Reverse()));
                        }
                        current = reader.ReadLine();
                    }
                }
            }
        }
    }
}

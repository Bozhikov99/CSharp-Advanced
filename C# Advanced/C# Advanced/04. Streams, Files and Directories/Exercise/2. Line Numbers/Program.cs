using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter writer=new StreamWriter("../../../output.txt"))
                {
                    string currentLine = reader.ReadLine();
                    int counter = 0;
                    while (currentLine!=null)
                    {
                        int letters = 0;
                        int punct = 0;
                        foreach (char c in currentLine)
                        {
                            if (char.IsLetter(c))
                            {
                                letters++;
                            }
                            else if (char.IsPunctuation(c))
                            {
                                punct++;
                            }
                        }
                        writer.WriteLine($"Line {++counter}: {currentLine} ({letters})({punct})");
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}


using System.Collections.Generic;
using System.IO;

namespace _03._Words_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] targetWords = File.ReadAllLines("../../../../words.txt");
            Dictionary<string, int> wordCounter = new Dictionary<string, int>();
            string text = File.ReadAllText("../../../../text.txt");
            foreach (string w in targetWords)
            {
                wordCounter[w] = 0;
            }

            string[] words = text
                .Split(new string[] { " ", "-", ".", ",", "?", "!" }, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string w in words)
            {
                if (wordCounter.ContainsKey(w.ToLower()))
                {
                    wordCounter[w.ToLower()]++;
                }
            }
            foreach (var w in wordCounter)
            {
                System.Console.WriteLine($"{w.Key} - {w.Value}");
            }
        }

    }
}


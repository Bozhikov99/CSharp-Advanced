using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._Directory_traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            var files = new Dictionary<string, Dictionary<string, double>>();
            foreach (string f in fileNames)
            {
                FileInfo info = new FileInfo(f);
                string extension = info.Extension;
                long size = f.Length;
                string name = info.Name;
                double kbSize = Math.Round(size / 1024.0, 3);

                if (!files.ContainsKey(extension))
                {
                    files[extension] = new Dictionary<string, double>();
                }
                if (!files[extension].ContainsKey(name))
                {
                    files[extension].Add(name, kbSize);
                }
            }
            Dictionary<string, Dictionary<string, double>> sorted = files
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            List<string> res = new List<string>();

            foreach (var item in sorted)
            {
                res.Add(item.Key);
                foreach (var file in item.Value.OrderBy(x=>x.Value))
                {
                    res.Add($"--{file.Key} - {file.Value}kb");
                }
            }
            string path=Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "output.txt");
            File.WriteAllLines("output.txt", res);
        }
    }
}

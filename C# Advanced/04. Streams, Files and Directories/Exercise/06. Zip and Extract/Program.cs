using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipArchive zip = ZipFile.Open("zipFile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry entry = 
                zip.CreateEntryFromFile("../../../../output.txt", "outputEntry.txt");
        }
    }
}

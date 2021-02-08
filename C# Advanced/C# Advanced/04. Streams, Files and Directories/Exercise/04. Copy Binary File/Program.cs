using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream readStream = new FileStream("../../../../copyMe.png", FileMode.Open);
            using FileStream writeStream = new FileStream("newImage.png", FileMode.Create);
            while (readStream.Position != readStream.Length)
            {

                byte[] buffer = new byte[4096];
                int n = readStream.Read(buffer, 0, buffer.Length);
                if (n == 0)
                {
                    break;
                }
                writeStream.Write(buffer);
            }

        }
    }
}

using System;
using System.Threading;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {

            var newFile = new Movie();

            newFile.BytesSent = 0;
            newFile.Length = 120;

            StreamProgressInfo stream = new StreamProgressInfo(newFile);

            while (stream.CalculateCurrentPercent()<100)
            {
                newFile.BytesSent+=24;
                Console.WriteLine($"Sending: {stream.CalculateCurrentPercent()} %");

                Thread.Sleep(70);
            }
        }
    }
}

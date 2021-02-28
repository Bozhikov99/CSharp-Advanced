using System;

namespace ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, heigth);
                Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurface():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

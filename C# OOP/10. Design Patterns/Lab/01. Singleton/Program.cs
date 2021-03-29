using System;

namespace _01._Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Washington, D.C."));
            Console.WriteLine(db.GetPopulation("London"));
        }
    }
}

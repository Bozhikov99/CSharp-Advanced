using System;

namespace _1._CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(3);
            list.Add(8);
            list.Add(5);
            list.Insert(3, 13);
            Console.WriteLine(list[1]);
        }
    }
}

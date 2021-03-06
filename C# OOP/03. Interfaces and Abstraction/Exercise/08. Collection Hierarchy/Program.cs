using System;
using System.Runtime.CompilerServices;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addcollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] items = Console.ReadLine()
                .Split();

            foreach (var item in items)
            {
                Console.Write($"{addcollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in items)
            {
                Console.Write($"{addRemoveCollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in items)
            {
                Console.Write($"{myList.Add(item)} ");
            }
            Console.WriteLine();

            int removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeCount; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }
            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
            Console.WriteLine();
        }
    }
}

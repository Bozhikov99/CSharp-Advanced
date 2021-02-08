using System;

namespace Doubly_linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            CustomLinkedList list = new CustomLinkedList();

            for (int i = 0; i <= n; i++)
            {
                list.AddLast(new Node(i));
            }

            Console.WriteLine(string.Join(", ", list.ToArray()));

        }
    }
}

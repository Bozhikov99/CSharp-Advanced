using System;

namespace Doubly_linked_list
{
    class CustomLinkedList
    {
        private int count = 0;
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public void AddFirst(Node newNode)
        {
            count++;
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        public void AddLast(Node newNode)
        {
            count++;
            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        public Node RemoveFirst()
        {
            count--;
            var returnNode = Head;
            if (Head == null)
            {
                return null;
            }
            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
            }
            return returnNode;
        }

        public Node RemoveLast()
        {
            count--;
            Node returnNode = Tail;
            if (Tail == null)
            {
                return null;
            }

            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Tail = null;
            }
            return returnNode;
        }

        public void ForEach(Action<Node> action)
        {
            Node current = Head;
            while (current != null)
            {
                action(current);
                current = current.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[count];
            Node current = Head;

            for (int i = 0; i < count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }

            return array;
        }
    }
}

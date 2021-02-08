using System;

namespace CustomDoublyLinkedList
{
    public class CustomLinkedList<T>
    {
        private int count = 0;
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public void AddFirst(Node<T> newNode)
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

        public void AddLast(Node<T> newNode)
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

        public Node<T> RemoveFirst()
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

        public Node<T> RemoveLast()
        {
            count--;
            Node<T> returnNode = Tail;
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

        public void ForEach(Action<Node<T>> action)
        {
            Node<T> current = Head;
            while (current != null)
            {
                action(current);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> current = Head;

            for (int i = 0; i < count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }

            return array;
        }
    }
}

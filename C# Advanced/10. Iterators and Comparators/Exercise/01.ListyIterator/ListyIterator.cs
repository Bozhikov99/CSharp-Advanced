using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index = 0;
        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }
        public ListyIterator(List<T> items)
        {
            this.items = new List<T>(items);
        }

        public bool HasNext() => index < items.Count - 1;

        public bool Move()
        {
            bool hasNext = HasNext();
            if (HasNext())
            {
                index++;
            }
            return hasNext;
        }

        public void Print()
        {
            if (index >= items.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
        }
    }
}

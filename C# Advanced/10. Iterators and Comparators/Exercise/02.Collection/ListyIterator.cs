using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T>: IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

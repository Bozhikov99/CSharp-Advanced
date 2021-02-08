using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> elements;
        public Box()
        {
            elements = new Stack<T>();
        }
        public int Count
        {
            get { return elements.Count; }
        }

        public void Add(T newElement)
        {
            elements.Push(newElement);
        }

        public T Remove()
        {
            return elements.Pop();
        }
    }
}

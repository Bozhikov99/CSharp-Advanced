using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList()
            : base()
        {
            elements = new Stack<string>();
        }
        private Stack<string> elements;
        public int Used => elements.Count;

        public override int Add(string newElement)
        {
            elements.Push(newElement);
            return 0;
        }
        public override string Remove()
        {
            return elements.Pop();
        }
    }
}

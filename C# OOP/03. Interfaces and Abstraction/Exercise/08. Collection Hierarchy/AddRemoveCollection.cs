using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public AddRemoveCollection()
            :base()
        {
            elements = new List<string>();
        }
        private const int defaultReturnIndex = 0;
        private List<string> elements;
        public virtual string Remove()
        {
            string current=elements.Last();
            elements.RemoveAt(elements.Count - 1);
            return current;
        }
        public override int Add(string newElement)
        {
            elements.Insert(0, newElement);

            return defaultReturnIndex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            elements = new List<string>();
        }
        private List<string> elements;
        public IReadOnlyCollection<string> Elements => elements.AsReadOnly();

        public virtual int Add(string newElement)
        {
            elements.Add(newElement);
            return elements.Count - 1;
        }
    }
}

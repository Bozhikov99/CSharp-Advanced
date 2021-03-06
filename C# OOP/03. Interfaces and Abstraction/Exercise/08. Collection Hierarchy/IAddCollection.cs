using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddCollection
    {
        IReadOnlyCollection<string> Elements { get; }
        int Add(string newElement);
    }
}

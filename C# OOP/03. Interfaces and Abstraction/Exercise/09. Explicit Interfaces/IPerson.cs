using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfeces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
        string GetName();
    }
}

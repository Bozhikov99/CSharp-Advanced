using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfeces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();
    }
}

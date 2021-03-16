using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}

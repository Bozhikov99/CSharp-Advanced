using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        public string Template { get => "{0} - {1} - {2}"; }
    }
}

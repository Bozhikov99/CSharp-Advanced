using Logger.Factories;
using Logger.Models;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout current = null;

            switch (type)
            {
                case nameof(SimpleLayout):
                    current = new SimpleLayout();
                    break;

                case nameof(XmlLayout):
                    current = new XmlLayout();
                    break;

                default:
                    throw new ArgumentException("Unsupported Type");
            }

            return current;
        }
    }
}

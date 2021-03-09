using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public class InvalidPersonNameException:Exception
    {
        public InvalidPersonNameException(string message,Exception innerException=null)
            : base(message, innerException)
        {
        }
    }
}

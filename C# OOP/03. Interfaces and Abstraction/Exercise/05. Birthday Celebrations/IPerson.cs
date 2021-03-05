using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson:IBirthable, IIdentifiable
    {
        public int Age { get;}
    }
}

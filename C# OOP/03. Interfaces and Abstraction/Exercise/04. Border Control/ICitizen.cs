using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen: IRobot
    {
        int Age { get; set; }
    }
}

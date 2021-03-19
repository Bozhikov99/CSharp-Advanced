using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int min, int max)
        {
            minValue = min;
            maxValue = max;
        }

        public override bool IsValid(object obj)
        {
            int objectInt = (int)obj;

            return objectInt >= minValue && objectInt <= maxValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
        where T:IComparable
    {
        private T left;
        private T right;
        public EqualityScale(T leftElement, T rightElement)
        {
            left = leftElement;
            right = rightElement;
        }

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        public string RandomString()
        {
            if (Count==0)
            {
                return null;
            }
            int index = new Random().Next(0, Count);
            string element=this[index];
            RemoveAt(index);
            return element;
        }
    }
}

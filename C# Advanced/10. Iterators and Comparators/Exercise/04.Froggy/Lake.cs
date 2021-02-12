using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> values;

        public Lake(params int[] numbers)
        {
            values = new List<int>(numbers);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < values.Count; i += 2)
            {
                yield return values[i];
            }

            int startIndex = values.Count % 2 == 0 ?
                values.Count - 1 :
                values.Count - 2;

            for (int i = startIndex; i >=0; i-=2)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

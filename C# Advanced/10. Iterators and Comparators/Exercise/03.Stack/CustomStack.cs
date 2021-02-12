using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class CustomStack: IEnumerable<int>
    {
        private List<int> values;


        public CustomStack()
        {
            values = new List<int>();
        }

        public void Push(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                values.Add(numbers[i]);
            }
        }

        public void Pop()
        {
            if (values.Count==0)
            {
                throw new InvalidOperationException("No elements");
            }
            values.RemoveAt(values.Count - 1);
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

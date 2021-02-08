using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._CustomList
{
    public class CustomList
    {
        private const int initialSize = 2;
        private int[] array;
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return array[index];
            }
            set
            {
                ValidateIndex(index);
                array[index] = value;
            }
        }


        public CustomList()
        {
            array = new int[initialSize];
        }

        public void Add(int number)
        {
            array[Count] = number;
            Count++;
            if (Count==array.Length)
            {
                Resize();
            }
        }


        public int RemoveAt(int i)
        {
            ValidateIndex(i);

            int returnNumber = array[i];
            array[i] = default;
            Count--;

            Shift(i);

            if (Count==array.Length/4)
            {
                Shrink();
            }
            return returnNumber;        
        }

        public bool Contains(int number)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i]==number)
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(int index, int number)
        {
            Count++;
            ValidateIndex(index);

            if (Count==array.Length)
            {
                Resize();
            }

            ShiftRight(index);
            array[index] = number;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count-1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            
        }

        public void Swap(int a, int b)
        {
            ValidateIndex(a);
            ValidateIndex(b);
            int save = array[a];
            array[a] = array[b];
            array[b] = save;
        }

        private void ValidateIndex(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count-1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void Resize()
        {
            int[] resizedArray = new int[Count * 2];
            Array.Copy(array, resizedArray, Count);
            array = resizedArray;
        }

        private void Shrink()
        {
            int[] shrinkedArray = new int[array.Length / 2];
            Array.Copy(array, shrinkedArray, Count);
            array = shrinkedArray;
        }
    }
}

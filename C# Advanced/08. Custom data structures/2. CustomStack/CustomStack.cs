using System;
using System.Collections.Generic;
using System.Text;

namespace _2._CustomStack
{
    class CustomStack
    {
        private const int initialArraySize = 4;

        public int Count { get; private set; }
        public int[] Content { get; set; }

        public CustomStack()
        {
            Content = new int[initialArraySize];
        }

        public void Push(int number)
        {
            if (Count == Content.Length)
            {
                Resize();
            }
            Content[Count] = number;
            Count++;
        }

        public int Pop()
        {
            ValidateLength();
            int number = Content[Count - 1];
            Count--;

            if (Count==Content.Length/4)
            {
                Shrink();
            }
            return number;
        }
        public int Peek()
        {
            ValidateLength();
            int number = Content[Count - 1];
            return number;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(Content[i]);
            }
        }

        private void Shrink()
        {
            int[] shrinked = new int[Content.Length / 2];
            Array.Copy(Content, shrinked, Count);
            Content = shrinked;
        }


        private void Resize()
        {
            int[] resizedArr = new int[Count * 2];
            Array.Copy(Content, resizedArr, Count);
            Content = resizedArr;
        }

        private void ValidateLength()
        {
            if (Content.Length == 0)
            {
                throw new NullReferenceException();
            }
        }
    }
}

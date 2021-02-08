using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var bracketIndexes = new Stack<int>();
            string expression = Console.ReadLine();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    bracketIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    Console.WriteLine(expression.Substring(bracketIndexes.Peek(), i-bracketIndexes.Pop()+1));
                }
            }
        }
    }
}

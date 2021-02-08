using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _8._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parenthesis = new Stack<char>();
            bool valid = true;

            foreach (var item in input)
            {
                switch (item)
                {
                    case '(':
                    case '[':
                    case '{':
                        parenthesis.Push(item);
                        break;
                    case ')':
                        if (parenthesis.Count > 0)
                        {
                            if (parenthesis.Peek() == '(')
                            {
                                parenthesis.Pop();
                            }
                            else
                            {
                                valid = false;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                        break;
                    case ']':
                        if (parenthesis.Count > 0)
                        {
                            if (parenthesis.Peek() == '[')
                            {
                                parenthesis.Pop();
                            }
                            else
                            {
                                valid = false;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                        break;
                    case '}':
                        if (parenthesis.Count > 0)
                        {
                            if (parenthesis.Peek() == '{')
                            {
                                parenthesis.Pop();
                            }
                            else
                            {
                                valid = false;
                            }
                        }
                        else
                        {
                            valid = false;
                        }
                        break;
                    default:
                        break;
                }
                if (valid == false)
                {
                    
                    break;
                }
            }

            if (valid == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

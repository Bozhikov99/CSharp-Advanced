using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExamRetake19._08._20
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int wreathCount = 0;
            int store = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Peek() + roses.Peek();

                if (sum == 15)
                {
                    wreathCount++;

                }
                else if (sum > 15)
                {
                    if (sum%2==1)
                    {
                        wreathCount++;
                    }
                    else
                    {
                        store += 14;
                    }
                    
                }
                else if (sum<15)
                {

                    store += sum;
                }
                lilies.Pop();
                roses.Dequeue();
            }
            wreathCount += store / 15;
            string output = wreathCount >= 5 ? $"You made it, you are going to the competition with {wreathCount} wreaths!" 
                : $"You didn't make it, you need {5-wreathCount} wreaths more!";

            Console.WriteLine(output);
        }
    }
}

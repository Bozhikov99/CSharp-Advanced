using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = cmd[0];
                decimal grade = decimal.Parse(cmd[1]);
                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }
                students[name].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (decimal grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}

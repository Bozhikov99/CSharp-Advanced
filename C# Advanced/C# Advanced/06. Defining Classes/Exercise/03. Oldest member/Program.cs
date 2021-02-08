using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = cmd[0];
                int age = int.Parse(cmd[1]);

                family.AddMember(new Person(name, age));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}

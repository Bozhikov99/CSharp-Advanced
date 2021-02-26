using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string cmd = Console.ReadLine();
            while (cmd!="Beast!")
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];


                if (string.IsNullOrEmpty(name) ||
                    int.Parse(tokens[1]) < 0 ||
                    string.IsNullOrEmpty(gender))

                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    if (cmd == "Dog")
                    {
                        Dog current = new Dog(name, age, gender);
                        Console.WriteLine(current);
                        Console.WriteLine(current.ProduceSound());
                    }
                    else if (cmd == "Cat")
                    {
                        Cat currentCat = new Cat(name, age, gender);
                        Console.WriteLine(currentCat);
                        Console.WriteLine(currentCat.ProduceSound());
                    }
                    else if (cmd == "Frog")
                    {
                        Frog currentFrog = new Frog(name, age, gender);
                        Console.WriteLine(currentFrog);
                        Console.WriteLine(currentFrog.ProduceSound());
                    }
                    else if (cmd == "Tomcat")
                    {
                        Tomcat currentTom = new Tomcat(name, age);
                        Console.WriteLine(currentTom);
                        Console.WriteLine(currentTom.ProduceSound());
                    }
                    else if (cmd=="Kitten")
                    {
                        Kitten currentKitty = new Kitten(name, age);
                        Console.WriteLine(currentKitty);
                        Console.WriteLine(currentKitty.ProduceSound());
                    }
                            
                }
                cmd = Console.ReadLine();
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Transactions;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] commands = cmd.Split();

                Animal currentAnimal = AnimalGenerator(commands);
                Console.WriteLine(currentAnimal.Sound());

                commands = Console.ReadLine()
                    .Split();

                Food currentFood = FoodGenerator(commands);
                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (ArgumentException x)
                {
                    Console.WriteLine(x.Message);
                }

                animals.Add(currentAnimal);
                cmd = Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Food FoodGenerator(string[] commands)
        {
            string type = commands[0];
            int quantity = int.Parse(commands[1]);

            if (type == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else if (type == nameof(Seeds))
            {
                return new Seeds(quantity);
            }

            return null;
        }

        private static Animal AnimalGenerator(string[] commands)
        {
            //Birds – "{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"
            //Felines – "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
            //Mice and Dogs – "{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"

            Animal current = null;

            string type = commands[0];
            string name = commands[1];
            double weight = double.Parse(commands[2]);

            if (type == nameof(Dog))
            {
                string region = commands[3];
                current = new Dog(name, weight, region);
            }
            else if (type == nameof(Mouse))
            {
                string region = commands[3];
                current = new Mouse(name, weight, region);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(commands[3]);
                current = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                double wingSize = double.Parse(commands[3]);
                current = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = commands[3];
                string breed = commands[4];
                current = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = commands[3];
                string breed = commands[4];
                current = new Tiger(name, weight, livingRegion, breed);
            }


            return current;
        }
    }
}

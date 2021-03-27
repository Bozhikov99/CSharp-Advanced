using _01._Singleton.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace _01._Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals= new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("../../../capitals.txt");

            for (int i = 0; i < elements.Length; i+=2)
            {
                string name = elements[i];
                int population = int.Parse(elements[i + 1]);

                capitals.Add(name,population);
            }

        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static SingletonDataContainer instance = new SingletonDataContainer();

        public static SingletonDataContainer Instance => instance;
    }
}

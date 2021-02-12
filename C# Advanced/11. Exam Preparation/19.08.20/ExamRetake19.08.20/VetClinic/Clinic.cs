using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>(capacity);
        }
        private List<Pet> pets;
        public int Capacity { get; set; }
        public int Count { get => pets.Count; }

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(p => p.Name == name);
            if (pets.Contains(pet))
            {
                pets.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            if (pets.Contains(pet))
            {
                return pet;
            }
            return null;
        }

        public Pet GetOldestPet()
        {
            return pets.OrderByDescending(p => p.Age)
                .First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet p in pets)
            {
                sb.AppendLine($"Pet {p.Name} with owner: {p.Owner}");
            }
            return sb.ToString();
        }
    }
}

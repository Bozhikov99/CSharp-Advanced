using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        private List<Employee> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get=>data.Count; }

        public void Add(Employee employee)
        {
            if (Capacity>Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);
            if (employee!=null)
            {
                data.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return data.Where(e => e.Name == name).First();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Employees working at Bakery {Name}:");
            foreach (Employee e in data)
            {
                output.AppendLine(e.ToString());
            }
            return output.ToString();
        }
    }
}

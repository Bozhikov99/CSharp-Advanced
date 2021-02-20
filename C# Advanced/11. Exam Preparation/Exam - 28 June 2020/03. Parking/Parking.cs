using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        private List<Car> data;

        public void Add(Car car)
        {
            if (Count<Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (carToRemove!=null)
            {
                data.Remove(carToRemove);
                return true;
            }
            return false;
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}

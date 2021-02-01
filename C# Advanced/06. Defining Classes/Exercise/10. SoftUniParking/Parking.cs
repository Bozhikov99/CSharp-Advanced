using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count => cars.Count;
        public Parking(int cap)
        {
            capacity = cap;
            cars = new List<Car>();
        }

        public string AddCar(Car Car)
        {
            if (cars.Any(c=>c.RegistrationNumber==Car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count==capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                cars.Add(Car);
                return $"Successfully added new car {Car.Make} { Car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registration)
        {
            if (cars.Any(c=>c.RegistrationNumber==registration))
            {
                cars = cars.Where(c => c.RegistrationNumber != registration)
                    .ToList();
                return $"Successfully removed {registration}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registration)
        {
            Car current = cars.FirstOrDefault(c=>c.RegistrationNumber==registration);
            return current;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrations)
        {
            cars = cars.Where(c=>!registrations.Contains(c.RegistrationNumber)).ToList();
        }
    }
}

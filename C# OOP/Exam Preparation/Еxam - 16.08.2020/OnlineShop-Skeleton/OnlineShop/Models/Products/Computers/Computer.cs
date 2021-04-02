using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer :Product, IComputer
    {
        private double computerPerformance;
        private decimal computerPrice;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double performance) 
            : base(id, manufacturer, model, price, performance)
        {
            computerPerformance = performance;
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public override double OverallPerformance { get=>GetPerformance(); }
        public override decimal Price { get => GetPrice(); }

        public void AddComponent(IComponent component)
        {
            if (components.Any(c=>c.GetType()==component.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,component.GetType().Name,GetType().Name,Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(c => c.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any(c=>c.GetType().Name==componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }

            IComponent component = components.First(c => c.GetType().Name == componentType);
            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }

            IPeripheral peripheral= peripherals.First(c => c.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({components.Count}):");

            foreach (IComponent c in components)
            {
                sb.AppendLine($"  {c}");
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripherals.Average(p=>p.OverallPerformance)}):");

            foreach (IPeripheral p in peripherals)
            {
                sb.AppendLine($"  {p}");
            }

            return sb.ToString().Trim();
        }

        private decimal GetPrice()
        {
            return computerPrice + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);
        }

        private double GetPerformance()
        {
            if (components.Count==0)
            {
                return computerPerformance;
            }
            return computerPerformance + Components.Average(c => c.OverallPerformance);
        }
    }
}

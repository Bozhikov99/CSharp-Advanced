using Microsoft.VisualBasic;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = components.FirstOrDefault(c => c.Id == id);

            ComputerIsContainedInCollection(computerId);

            if (component!=null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (componentType=="CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance,generation);
            }

            else if (componentType=="PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType=="Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType=="VideoCard")
            {
                component=new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            components.Add(component);

            IComputer computer = computers.First(c => c.Id == computerId);
            computer.AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == id);

            if (computer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral= peripherals.FirstOrDefault(c => c.Id == id);

            ComputerIsContainedInCollection(computerId);

            if (peripheral!= null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheral);
            }

            if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            peripherals.Add(peripheral);

            IComputer computer = computers.First(c => c.Id == computerId);
            computer.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            ComputerIsContainedInCollection(id);

            IComputer computer = computers.First(c => c.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            ComputerIsContainedInCollection(id);

            return computers.First(c => c.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ComputerIsContainedInCollection(computerId);

            IComponent component = components.FirstOrDefault(c => c.GetType().Name == componentType);
            IComputer computer = computers.First(c => c.Id == computerId);

            if (component==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computerId));
            }

            components.Remove(component);
            computer.RemoveComponent(componentType);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ComputerIsContainedInCollection(computerId);

            IPeripheral peripheral= peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            IComputer computer = computers.First(c => c.Id == computerId);

            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computer.GetType().Name, computerId));
            }

            peripherals.Remove(peripheral);
            computer.RemovePeripheral(peripheralType);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private bool ComputerIsContainedInCollection(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return true;
        }
    }
}

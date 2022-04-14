using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private IList<IComputer> computers;
        private IList<IComponent> components;
        private IList<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent
            (int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfPCExist(computerId);

            if (componentType != "CentralProcessingUnit" && componentType != "Motherboard" && componentType != "PowerSupply"
                && componentType != "RandomAccessMemory" && componentType != "SolidStateDrive" && componentType != "VideoCard")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent component = default;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
                      
            if (components.Contains(component))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            computer.AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computerType != "Laptop" && computerType != "DesktopComputer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            else if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = default;

            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral
            (int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfPCExist(computerId);

            if (peripheralType != "Headset" && peripheralType != "Keyboard" && peripheralType != "Monitor" && peripheralType != "Mouse")
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral peripheral = default;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType != "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType != "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            computers.OrderByDescending(x => x.OverallPerformance);
            var computer = computers.FirstOrDefault(c => c.Price <= budget);

            if (computers.Count == 0 || computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfPCExist(id);

            var computer = computers.FirstOrDefault(c => c.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfPCExist(id);

            var computer = computers.FirstOrDefault(c => c.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfPCExist(computerId);

            var component = components.FirstOrDefault(c => c.GetType().Name == componentType);
            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            if (computer != null && component != null)
            {
                computer.RemoveComponent(componentType);
                components.Remove(component);
                return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computerId));
            }
            
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfPCExist(computerId);

            var peripheral = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            if (computer != null && peripheral != null)
            {
                computer.RemovePeripheral(peripheralType);
                peripherals.Remove(peripheral);
                return string.Format(SuccessMessages.RemovedComponent, peripheralType, peripheral.Id);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computer.GetType().Name, computerId));
            }         
        }

        private void CheckIfPCExist(int id)
        {
            if (!computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}

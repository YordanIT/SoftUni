using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly IList<IComponent> components;
        private readonly IList<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>) peripherals;

        public override decimal Price => base.Price + Components.Sum(c => c.Price) + Peripherals.Sum(p => p.Price);
        public void AddComponent(IComponent component)
        {
            if (Components.Any(c => c.Id == component.Id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (!Components.Contains(component) || Components.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, component.GetType().Name, GetType().Name, Id));
            }

            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (Peripherals.Contains(peripheral) || Peripherals.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine
                ($" Peripherals ({Peripherals.Count}); Average Overall Performance ({(Peripherals.Count != 0 ? Peripherals.Average(p => p.OverallPerformance) : 0)}))");

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().Trim();
        }
    }
}

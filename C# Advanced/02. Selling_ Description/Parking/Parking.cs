using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data = new List<Car>();
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>(capacity);
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model) => 
            data.Remove(data.Find(c => c.Manufacturer == manufacturer && c.Model == model));
        public Car GetLatestCar() => data.OrderByDescending(c => c.Year).FirstOrDefault();
        public Car GetCar(string manufacturer, string model) =>
            data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));

            return sb.ToString().TrimEnd();
        }
    }
}

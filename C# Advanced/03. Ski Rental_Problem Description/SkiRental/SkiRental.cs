using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>(capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model) => 
            data.Remove(data.Find(s => s.Manufacturer == manufacturer && s.Model == model));
        public Ski GetNewestSki() => data.OrderByDescending(s => s.Year).FirstOrDefault();
        public Ski GetSki(string manufacturer, string model) =>
            data.Find(s => s.Manufacturer == manufacturer && s.Model == model);
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>(Capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Racer racer)
        {
            if (data.Count <= Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            if (data.Exists(r => r.Name == name))
            {
                data.Remove(data.Find(r => r.Name == name));
                return true;
            }

            return false;
        }
        public Racer GetOldestRacer() => data.OrderByDescending(x => x.Age).First();
        public Racer GetRacer(string name) => data.Find(x => x.Name == name);
        public Racer GetFastestRacer() => data.OrderByDescending(x => x.Car.Speed).First();
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));

            return sb.ToString().TrimEnd();
        }
    }
}

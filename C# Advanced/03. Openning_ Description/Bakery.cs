using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>(capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Employee employee)
        {
            if (Capacity > data.Count)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name) => data.Remove(data.Find(e => e.Name == name));
        public Employee GetOldestEmployee()
        {
           data.OrderByDescending(e => e.Age);
            return data.FirstOrDefault();
        }
        public Employee GetEmployee(string name) => data.Find(e => e.Name == name);
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));

            return sb.ToString().TrimEnd();
        }

    }
}

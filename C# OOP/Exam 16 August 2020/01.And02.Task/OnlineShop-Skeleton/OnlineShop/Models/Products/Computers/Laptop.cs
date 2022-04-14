using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        private const double overallPerformance = 10;
        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, overallPerformance)
        {
        }
        public override double OverallPerformance => Components.Count == 0 ? base.OverallPerformance :
            Components.Average(c => c.OverallPerformance) + overallPerformance;
    }
}

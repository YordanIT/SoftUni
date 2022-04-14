using Bakery.Models.Drinks.Contracts;
using System;

namespace Bakery.Utilities.Messages
{
    public class Drink : IDrink
    {
        public Drink(string name, int portion, decimal price, string brand)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            Name = name;

            if (portion <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPortion);
            }

            Portion = portion;

            if (price <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPrice);
            }

            Price = price;

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            Brand = brand;
        }
        public string Name { get; }

        public int Portion { get; }

        public decimal Price { get; }

        public string Brand { get; }

        public override string ToString()
        {
            return $"{Name} {Brand} - {Portion}ml - {Price:f2}lv";
        }
    }
}

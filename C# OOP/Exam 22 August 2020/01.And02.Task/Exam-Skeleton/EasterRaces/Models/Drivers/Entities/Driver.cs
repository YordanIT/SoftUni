using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        public Driver(string name)
        {
            Name = name;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value , 5));
                }

                name = value;
            }
        }

        public ICar Car 
        {
            get => car;
            private set
            {
                car = value ?? throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; } = false;

        public void AddCar(ICar car)
        {
            Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}

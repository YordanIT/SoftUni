using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<ICar> cars = new CarRepository();
        private readonly IRepository<IDriver> drivers = new DriverRepository();
        private readonly IRepository<IRace> races = new RaceRepository();
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = drivers.GetByName(driverName);
            var car = cars.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = races.GetByName(raceName);
            var driver = drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = default;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            var driver = new Driver(driverName);

            if (drivers.GetByName(driverName) == driver)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);

            if (races.GetByName(name) == race)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            int countOfParticipants = race.Drivers.Count;

            if (countOfParticipants < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            int laps = race.Laps;

            Dictionary<string, double> winners = new Dictionary<string, double>();

            foreach (var driver in race.Drivers)
            {
                winners[driver.Name] = driver.Car.CalculateRacePoints(laps);
            }
    
            races.Remove(race);
            
            var sb = new StringBuilder();
            int counter = 1;

            foreach (var winner in winners.OrderByDescending(w => w.Value))
            {
                if (counter == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winner.Key, raceName));

                    string champName = winner.Key;
                    var champ = race.Drivers.First(d => d.Name == champName);
                    champ.WinRace();

                    counter++;
                }
                else if (counter == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winner.Key, raceName));

                    counter++;
                }
                else if (counter == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winner.Key, raceName));

                    counter++;
                }
                else
                {
                    break;
                }
            }
                        
            return sb.ToString().Trim();
        }
    }
}

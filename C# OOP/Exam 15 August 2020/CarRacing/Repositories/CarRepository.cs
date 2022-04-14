using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IList<ICar> models;
        public CarRepository()
        {
            models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }
        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
        public ICar FindBy(string property)
        {
            ICar car = models.FirstOrDefault(m => m.VIN == property);

            return car;
        }

        
    }
}

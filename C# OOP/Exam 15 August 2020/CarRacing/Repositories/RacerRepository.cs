using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly IList<IRacer> racers;
        public RacerRepository()
        {
            racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)racers;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            racers.Add(model);
        }
        public bool Remove(IRacer model)
        {
            return racers.Remove(model);
        }
        public IRacer FindBy(string property)
        {
            IRacer racer = racers.FirstOrDefault(m => m.Username == property);

            return racer;
        }

        
    }
}

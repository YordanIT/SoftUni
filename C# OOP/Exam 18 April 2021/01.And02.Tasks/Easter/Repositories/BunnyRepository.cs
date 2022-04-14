using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;
        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunnies;

        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }

        public IBunny FindByName(string name)
        {
            var bunny = bunnies.FirstOrDefault(x => x.Name == name);

            return bunny;
        }

        public bool Remove(IBunny model)
        {
            return bunnies.Remove(model);
        }
    }
}

using EasterRaces.Models.Cars.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
           public override ICar GetByName(string name)
        {
            return collection.FirstOrDefault(x => x.Model == name);
        }
    }
}

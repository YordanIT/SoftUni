﻿using EasterRaces.Models.Drivers.Contracts;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return collection.FirstOrDefault(x => x.Name == name);
        }
    }
}

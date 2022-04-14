using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly IList<T> collection = new List<T>();
        public void Add(T model)
        {
            collection.Add(model);
        }
        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)collection;
        }

        public virtual T GetByName(string name)
        {
            T entity = default;

            return entity;
        }

        public bool Remove(T model)
        {
            return collection.Remove(model);
        }
    }
}

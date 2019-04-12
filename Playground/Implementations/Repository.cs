using Microsoft.EntityFrameworkCore;
using Playground.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PlaygroundContext context;
        private DbSet<T> entities;

        public Repository(PlaygroundContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
    }
}

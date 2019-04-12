using System.Collections.Generic;

namespace Playground.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}

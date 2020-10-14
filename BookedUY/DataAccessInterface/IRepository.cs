using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Add(T obj);

        T Delete(T obj);

        T GetById(int id);
    }
}
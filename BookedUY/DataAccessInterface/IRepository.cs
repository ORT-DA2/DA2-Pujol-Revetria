using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Add(T obj);

        void Delete(T obj);

        T GetById(int id);
    }
}

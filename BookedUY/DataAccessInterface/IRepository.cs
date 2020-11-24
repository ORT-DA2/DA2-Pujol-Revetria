using System;
using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T AddAndSave(T obj);

        T Delete(T obj);

        T GetById(int id);
    }
}
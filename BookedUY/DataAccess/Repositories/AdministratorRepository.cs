using DataAccess.Context;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AdministratorRepository : IRepository<Administrator>
    {
        private DbSet<Administrator> administrators;
        private BookedUYContext bookedUYContext;

        public AdministratorRepository(BookedUYContext context)
        {
            this.bookedUYContext = context;
            this.administrators = context.Set<Administrator>();
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.administrators;
        }

        public void Delete(Administrator administrator)
        {
            this.administrators.Remove(administrator);
            bookedUYContext.SaveChanges();
        }

        public void Add(Administrator obj)
        {
            this.administrators.Add(obj);
            bookedUYContext.SaveChanges();
        }

        public Administrator GetById(int id)
        {
            return administrators.Find(id);
        }
    }
}

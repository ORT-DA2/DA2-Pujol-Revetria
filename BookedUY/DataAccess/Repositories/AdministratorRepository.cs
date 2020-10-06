using DataAccess.Context;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
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

        public Administrator GetByEmail(string email)
        {
            return administrators.Where(a => a.Email == email).FirstOrDefault();
        }

    }
}

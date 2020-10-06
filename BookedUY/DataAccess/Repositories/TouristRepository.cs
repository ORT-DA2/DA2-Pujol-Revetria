using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class TouristRepository : ITouristRepository
    {
        private readonly DbSet<Tourist> tourists;
        private readonly DbContext bookUYContext;

        public TouristRepository(DbContext bookUYContext)
        {
            this.bookUYContext = bookUYContext;
            this.tourists = bookUYContext.Set<Tourist>();
        }

        public void Add(Tourist obj)
        {
            this.tourists.Add(obj);
            this.bookUYContext.SaveChanges();
        }

        public void Delete(Tourist obj)
        {
            this.tourists.Remove(obj);
            this.bookUYContext.SaveChanges();
        }

        public IEnumerable<Tourist> GetAll()
        {
            return this.tourists;
        }

        public Tourist GetById(int id)
        {
            return this.tourists.Find(id);
        }

        public Tourist GetByEmail(string email)
        {
            return this.tourists.Where(t => t.Email == email).FirstOrDefault();
        }
    }
}

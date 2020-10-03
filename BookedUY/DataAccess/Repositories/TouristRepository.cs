using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class TouristRepository : IRepository<Tourist>
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
            throw new NotImplementedException();
        }

        public void Delete(Tourist obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tourist> GetAll()
        {
            return this.tourists;
        }

        public Tourist GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

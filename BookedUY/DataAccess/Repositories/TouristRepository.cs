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

        public IEnumerable<Tourist> GetAll()
        {
            return this.tourists;
        }

    }
}

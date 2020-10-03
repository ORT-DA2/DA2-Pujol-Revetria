using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class RegionRepository : IRepository<Region>
    {
        private readonly DbSet<Region> regions;
        private readonly DbContext bookUYContext;

        public RegionRepository(DbContext bookUYContext)
        {
            this.bookUYContext = bookUYContext;
            this.regions = bookUYContext.Set<Region>();
        }

        public void Add(Region obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Region obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Region> GetAll()
        {
            return this.regions;
        }

        public Region GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

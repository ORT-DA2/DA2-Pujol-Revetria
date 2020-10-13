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

        public Region Add(Region obj)
        {
            this.regions.Add(obj);
            bookUYContext.SaveChanges();
            return obj;
        }

        public Region Delete(Region obj)
        {
            this.regions.Remove(obj);
            bookUYContext.SaveChanges();
            return obj;
        }

        public IEnumerable<Region> GetAll()
        {
            return this.regions;
        }

        public Region GetById(int id)
        {
            return this.regions.Find(id);
        }
    }
}

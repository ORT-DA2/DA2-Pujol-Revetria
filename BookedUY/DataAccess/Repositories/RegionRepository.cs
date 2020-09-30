using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DbSet<Region> regions;
        private readonly DbContext bookUYContext;

        public RegionRepository(DbContext bookUYContext)
        {
            this.bookUYContext = bookUYContext;
            this.regions = bookUYContext.Set<Region>();
        }

        public IEnumerable<Region> GetAll()
        {
            return this.regions;
        }
        
    }
}

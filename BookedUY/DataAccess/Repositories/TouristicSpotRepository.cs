using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class TouristicSpotRepository : ITouristicSpotRepository
    {
        private readonly DbSet<TouristicSpot> spots;
        private readonly DbContext bookUYContext;

        public TouristicSpotRepository(DbContext bookUYContext)
        {
            this.bookUYContext = bookUYContext;
            this.spots = bookUYContext.Set<TouristicSpot>();
        }

        public IEnumerable<TouristicSpot> GetAll()
        {
            return this.spots;
        }
    }
}

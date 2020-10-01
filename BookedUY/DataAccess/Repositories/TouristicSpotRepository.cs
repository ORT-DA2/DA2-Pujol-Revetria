using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public void Add(TouristicSpot spot)
        {
            this.spots.Add(spot);
            this.bookUYContext.SaveChanges();
        }

        public IEnumerable<TouristicSpot> GetFromRegion(int id)
        {
            return this.spots.Where(s => s.RegionId == id);
        }

        public IEnumerable<TouristicSpot> GetFromCategory(List<int> categoriesId)
        {
            return this.spots.Where(s => s.Categories.Any(c => categoriesId.Contains(c.CategoryId)));
        }

        public IEnumerable<TouristicSpot> GetFromCategoryAndRegion(List<int> category, int region)
        {
            IEnumerable<TouristicSpot> touristicSpotFromCategory = GetFromCategory(category);
            return GetFromRegion(region).Where(l => touristicSpotFromCategory.Contains(l));
        }

        public TouristicSpot GetByID(int id)
        {
            return this.spots.Where(t => t.Id == id).First();
        }
    }
}

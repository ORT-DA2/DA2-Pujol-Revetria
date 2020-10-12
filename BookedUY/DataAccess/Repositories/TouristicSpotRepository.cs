using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return this.spots.Include(t=>t.Region).Include(t=>t.Categories).Include(t=>t.Image);
        }

        public TouristicSpot Add(TouristicSpot spot)
        {
            this.spots.Add(spot);
            this.bookUYContext.SaveChanges();
            return spot;
        }

        public IEnumerable<TouristicSpot> GetByRegion(int id)
        {
            return this.spots.Include(t => t.Region).Include(t => t.Categories).Include(t => t.Image).Where(s => s.RegionId == id);
        }

        public IEnumerable<TouristicSpot> GetByCategory(List<int> categoriesId)
        {
            var all = GetAll();
            List<TouristicSpot> list = new List<TouristicSpot>();
            foreach (TouristicSpot item in all)
            {
                if(categoriesId.All(c => null != item.Categories.Find(k => k.CategoryId == c)))
                {
                    list.Add(item);
                }
            }
            return list;
            //var customers = this.spots.Where("Categories.Contains(@0)", categoriesId);

            //return this.spots.Include(t => t.Region).AsQueryable().AsQueryable()
            //    .Where("@0.Contains(outerIt.)", categoriesId);
                //new List<string>() { "Austria", "Poland" }, 1955);
            //.Where(s => s.Categories.Any(c => categoriesId.Contains(c.CategoryId)));
        }

        public IEnumerable<TouristicSpot> GetByCategoryAndRegion(List<int> category, int region)
        {
            IEnumerable<TouristicSpot> touristicSpotFromCategory = GetByCategory(category);
            return GetByRegion(region).Where(l => touristicSpotFromCategory.Contains(l));
        }

        public TouristicSpot GetById(int id)
        {
            return this.spots.Find(id);
        }

        public void Delete(TouristicSpot touristicSpot)
        {
            this.spots.Remove(touristicSpot);
            bookUYContext.SaveChanges();
        }

        public TouristicSpot GetByName(string name)
        {
            return spots.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}

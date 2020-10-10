﻿using DataAccessInterface;
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
            return this.spots.Include(t=>t.Region);
        }

        public TouristicSpot Add(TouristicSpot spot)
        {
            this.spots.Add(spot);
            this.bookUYContext.SaveChanges();
            return spot;
        }

        public IEnumerable<TouristicSpot> GetByRegion(int id)
        {
            return this.spots.Include(t => t.Region).Where(s => s.RegionId == id);
        }

        public IEnumerable<TouristicSpot> GetByCategory(List<int> categoriesId)
        {
            return this.spots.Include(t => t.Region).Where(s => s.Categories.Any(c => categoriesId.Contains(c.CategoryId)));
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

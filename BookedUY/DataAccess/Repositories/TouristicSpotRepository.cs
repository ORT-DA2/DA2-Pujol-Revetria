﻿using DataAccessInterface;
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
            return this.spots.Include(t => t.Region).Include(t => t.Categories);
        }

        public TouristicSpot AddAndSave(TouristicSpot spot)
        {
            this.spots.Add(spot);
            this.bookUYContext.SaveChanges();
            return spot;
        }

        public IEnumerable<TouristicSpot> GetByRegion(int id)
        {
            return this.spots.Include(t => t.Region).Include(t => t.Categories).Where(s => s.RegionId == id);
        }

        public IEnumerable<TouristicSpot> GetByCategory(List<int> categoriesId)
        {
            var all = GetAll();
            List<TouristicSpot> list = new List<TouristicSpot>();
            foreach (TouristicSpot item in all)
            {
                if (categoriesId.All(c => null != item.Categories.Find(k => k.CategoryId == c)))
                {
                    list.Add(item);
                }
            }
            return list;
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

        public TouristicSpot Delete(TouristicSpot touristicSpot)
        {
            this.spots.Remove(touristicSpot);
            bookUYContext.SaveChanges();
            return touristicSpot;
        }

        public TouristicSpot GetByName(string name)
        {
            return spots.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
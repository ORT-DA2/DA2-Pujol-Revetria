﻿using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly DbSet<Accommodation> accommodations;
        private readonly DbContext bookedUYContext;


        public AccommodationRepository(DbContext context)
        {
            this.bookedUYContext = context;
            this.accommodations = context.Set<Accommodation>();
        }

        public IEnumerable<Accommodation> GetAll()
        {
            return this.accommodations.Include(a => a.Spot).Include(a => a.Images);
        }

        public Accommodation AddAndSave(Accommodation accommodation)
        {
            this.accommodations.Add(accommodation);
            bookedUYContext.SaveChanges();
            return accommodation;
        }

        public Accommodation Delete(Accommodation accommodation)
        {
            this.accommodations.Remove(accommodation);
            this.bookedUYContext.SaveChanges();
            return accommodation;
        }

        public Accommodation GetById(int id)
        {
            return this.accommodations.Include(a => a.Spot).Include(a => a.Images).Where(a => a.Id == id).SingleOrDefault();
        }

        public Accommodation GetByName(string name)
        {
            return this.accommodations.Include(a => a.Spot).Include(a => a.Images).Where(a => a.Name == name).FirstOrDefault();
        }

        public IEnumerable<Accommodation> GetAvailableBySpot(int spotId)
        {
            return this.accommodations.Include(a => a.Spot).Include(a => a.Images).Where(a => a.SpotId == spotId && a.Full == false);
        }

        public void UpdateCapacity(int accommodationId, bool capacity)
        {
            var accommodation = this.accommodations.Find(accommodationId);
            accommodation.Full = capacity;
            this.accommodations.Update(accommodation);
            this.bookedUYContext.SaveChanges();
        }
    }
}
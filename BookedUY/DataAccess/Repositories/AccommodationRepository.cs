using DataAccess.Context;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AccommodationRepository : IRepository<Accommodation>
    {
        private DbSet<Accommodation> accommodations;
        private BookedUYContext bookedUYContext;

        public AccommodationRepository(BookedUYContext context)
        {
            this.bookedUYContext = context;
            this.accommodations = context.Set<Accommodation>();
        }

        public IEnumerable<Accommodation> GetAll()
        {
            return this.accommodations;
        }

        public void Add(Accommodation accommodation)
        {
            this.accommodations.Add(accommodation);
            bookedUYContext.SaveChanges();
        }

        public void Delete(Accommodation accommodation)
        {
            this.accommodations.Remove(accommodation);
            this.bookedUYContext.SaveChanges();
        }

        public Accommodation GetById(int id)
        {
            return this.accommodations.Find(id);
        }
    }
}

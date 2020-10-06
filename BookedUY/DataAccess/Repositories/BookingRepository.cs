using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using System;
using System.Collections.Generic;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly DbSet<Booking> bookings;
        private readonly DbContext bookedUYContext;

        public BookingRepository(DbContext context)
        {
            this.bookedUYContext = context;
            this.bookings = context.Set<Booking>();
            
        }

        public IEnumerable<Booking> GetAll()
        {
            return this.bookings;
        }

        public void Add(Booking booking)
        {
            this.bookings.Add(booking);
            this.bookedUYContext.SaveChanges();
        }

        public Booking GetById(int id)
        {
            return this.bookings.Find(id);
        }

        public void Delete(Booking booking)
        {
            this.bookings.Remove(booking);
        }
    }
}

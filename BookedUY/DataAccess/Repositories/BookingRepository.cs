using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return this.bookings.Include(b => b.Accommodation).Include(b => b.Guests).Include(b => b.HeadGuest);
        }

        public Booking Add(Booking booking)
        {
            this.bookings.Add(booking);
            this.bookedUYContext.SaveChanges();
            return booking;
        }

        public Booking GetById(int id)
        {
            return this.bookings.Include(b => b.Accommodation).Include(b => b.Guests).Include(b => b.HeadGuest).Where(b => b.Id == id).SingleOrDefault();
        }

        public Booking Delete(Booking booking)
        {
            this.bookings.Remove(booking);
            this.bookedUYContext.SaveChanges();
            return booking;
        }
    }
}
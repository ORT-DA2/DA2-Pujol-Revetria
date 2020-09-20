using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbSet<Booking> bookings;
        private readonly DbContext bookedUYContext;

        public BookingRepository(DbContext context)
        {
            this.bookedUYContext = context ?? throw new ArgumentNullException(nameof(bookedUYContext));
            this.bookings = context.Set<Booking>();
        }
    }
}

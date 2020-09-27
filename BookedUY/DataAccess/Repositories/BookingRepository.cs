using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using System;
using System.Collections.Generic;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private DbSet<Booking> bookings;
        private BookedUYContext bookedUYContext;

        public BookingRepository(BookedUYContext context)
        {
            this.bookedUYContext = context;
            this.bookings = context.Set<Booking>();
            
        }

        //public List<Booking> GetBookings()
        //{
        //    using (var context = new BookedUYContext())
        //    {
        //        context.Boo
        //    }
        //}
    }
}

using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class BookingStageRepository : IBookingStageRepository
    {
        private readonly DbSet<BookingStage> bookingStages;
        private readonly DbContext bookUYContext;

        public BookingStageRepository(DbContext bookUYContext)
        {
            this.bookUYContext = bookUYContext;
            this.bookingStages = bookUYContext.Set<BookingStage>();
        }

        public IEnumerable<BookingStage> GetAll()
        {
            return this.bookingStages;
        }

        public BookingStage Add(BookingStage bookingStage)
        {
            this.bookingStages.Add(bookingStage);
            bookUYContext.SaveChanges();
            return bookingStage;
        }

        public IEnumerable<BookingStage> GetByBooking(int id)
        {
            return this.bookingStages.Where(b => b.AsociatedBookingId == id);
        }

        public void Delete(BookingStage obj)
        {
            this.bookingStages.Remove(obj);
            this.bookUYContext.SaveChanges();
        }

        public BookingStage GetById(int id)
        {
            return this.bookingStages.Find(id);
        }
    }
}

using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}

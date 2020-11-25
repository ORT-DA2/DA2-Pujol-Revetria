using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
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

        public Booking AddAndSave(Booking booking)
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

        public IList<ReportTuple> GetReport(int touristicSpotId, DateTime start, DateTime end)
        {
            return this.bookings.Include(b => b.Accommodation).Include(b => b.BookingHistory).
                Where(b => b.Accommodation.SpotId == touristicSpotId
                && b.BookingHistory.OrderByDescending(c => c.EntryDate).FirstOrDefault().Status != Status.Rejected
                && b.BookingHistory.OrderByDescending(c => c.EntryDate).FirstOrDefault().Status != Status.Expired
                && ((b.CheckIn >= start && b.CheckIn <= end) || (b.CheckOut <= end && b.CheckOut >= start) || (b.CheckIn<=start && b.CheckOut>=end)))
                .GroupBy(b => b.Accommodation.Id).Select(b => new ReportTuple(){ Id = b.Key, Count = b.Count() })
                .OrderByDescending(b=>b.Count).ThenBy(b=>b.Id).ToList();


            /*var aux = this.bookings.Include(b => b.Accommodation).Include(b => b.BookingHistory)
                .Where(b => b.Accommodation.SpotId == touristicSpotId
                && b.BookingHistory.Last().Status != Status.Expired
                && b.BookingHistory.Last().Status != Status.Rejected
                && ((b.CheckIn >= start && b.CheckOut <= start) || (b.CheckIn >= end && b.CheckOut <= end)));
            return aux.Select<string, int>(b => (b.Key, b.Count));
            return aux.GroupBy(b => b.Accommodation.Name).Select<string, int>(b => (b.Key, b.Count);
            

            Skip(b.BookingHistory.Count).First()
             */

        }
    }
}
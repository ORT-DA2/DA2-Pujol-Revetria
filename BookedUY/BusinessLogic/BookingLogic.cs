using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IRepository<Booking> bookingRepository;
        public BookingLogic(IRepository<Booking> bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public void AddBooking(Booking booking)
        {
            double totalprice = CalculateTotalPrice(booking);
            booking.TotalPrice = totalprice;
            this.bookingRepository.Add(booking);
        }

        private double CalculateTotalPrice(Booking booking)
        {
            double total = 0;
            foreach (Guest guest in booking.Guests)
            {
                total += guest.Amount * guest.Multiplier;
            }
            return total;
        }

        public IEnumerable<Booking> GetAll()
        {
            return this.bookingRepository.GetAll();
        }
    }
}

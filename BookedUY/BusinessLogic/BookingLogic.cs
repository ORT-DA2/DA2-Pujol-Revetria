using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IRepository<Booking> bookingRepository;
        public BookingLogic(IRepository<Booking> bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
    }
}

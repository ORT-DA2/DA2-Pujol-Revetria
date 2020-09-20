using BusinessLogicInterface;
using DataAccessInterface;
using System;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;

        public BookingLogic(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
    }
}

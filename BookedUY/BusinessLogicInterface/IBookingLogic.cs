using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IBookingLogic
    {
        //object GetBookings();
        void AddBooking(Booking booking);

        IEnumerable<Booking> GetAll();
    }
}

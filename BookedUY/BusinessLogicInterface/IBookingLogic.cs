using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IBookingLogic
    {
        Booking AddBooking(Booking booking);

        IEnumerable<Booking> GetAll();
    }
}

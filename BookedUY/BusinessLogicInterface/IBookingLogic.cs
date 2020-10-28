using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IBookingLogic
    {
        Booking AddBooking(Booking booking);

        IEnumerable<Booking> GetAll();

        Booking GetById(int id);
        List<(string, int)> GetReport(string touristicSpotName, DateTime start, DateTime end);
    }
}
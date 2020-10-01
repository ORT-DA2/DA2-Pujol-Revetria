using Domain;
using System;
using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        void Add(Booking booking);
    }
}

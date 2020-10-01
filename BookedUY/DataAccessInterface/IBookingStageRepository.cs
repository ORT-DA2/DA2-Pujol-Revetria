using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IBookingStageRepository
    {
        IEnumerable<BookingStage> GetAll();
        void Add(BookingStage bookingStage);
    }
}

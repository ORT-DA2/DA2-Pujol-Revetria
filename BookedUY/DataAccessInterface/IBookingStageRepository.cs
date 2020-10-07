using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IBookingStageRepository:IRepository<BookingStage>
    {
        IEnumerable<BookingStage> GetByBooking(int id);        
    }
}

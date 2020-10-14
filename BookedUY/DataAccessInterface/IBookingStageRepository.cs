using Domain;
using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface IBookingStageRepository : IRepository<BookingStage>
    {
        IEnumerable<BookingStage> GetByBooking(int id);
    }
}
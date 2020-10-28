using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IBookingRepository:IRepository<Booking>
    {
        List<(string, int)> GetReport(int touristicSpotId, DateTime start, DateTime end);
    }
}

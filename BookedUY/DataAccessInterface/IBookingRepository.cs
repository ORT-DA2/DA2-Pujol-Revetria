using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessInterface
{
    public interface IBookingRepository:IRepository<Booking>
    {
        IList<ReportTuple> GetReport(int touristicSpotId, DateTime start, DateTime end);
    }
}

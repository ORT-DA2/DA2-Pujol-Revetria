using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface IBookingStageLogic
    {
        BookingStage AddBookingStage(BookingStage stage);
        BookingStage GetCurrentStatusByBooking(int bookingId);
    }
}

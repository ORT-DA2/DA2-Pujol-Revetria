using DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class BookingStageLogic
    {
        private readonly IBookingStageRepository bookingStageRepository;

        public BookingStageLogic(IBookingStageRepository bookingStageRepository)
        {
            this.bookingStageRepository = bookingStageRepository;
        }
    }
}

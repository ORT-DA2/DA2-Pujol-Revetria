using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class BookingStageLogic
    {
        private readonly IRepository<BookingStage> bookingStageRepository;

        public BookingStageLogic(IRepository<BookingStage> bookingStageRepository)
        {
            this.bookingStageRepository = bookingStageRepository;
        }
    }
}

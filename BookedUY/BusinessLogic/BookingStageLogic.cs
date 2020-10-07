using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class BookingStageLogic : IBookingStageLogic
    {
        private readonly IRepository<BookingStage> bookingStageRepository;

        public BookingStageLogic(IRepository<BookingStage> bookingStageRepository)
        {
            this.bookingStageRepository = bookingStageRepository;
        }

        public BookingStage AddBookingStage(BookingStage stage)
        {
            var newStage = this.bookingStageRepository.Add(stage);
            return newStage;
        }
    }
}

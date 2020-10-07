using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class BookingStageLogic : IBookingStageLogic
    {
        private readonly IBookingStageRepository bookingStageRepository;
        private readonly IBookingStageRepository bookingRepository;

        public BookingStageLogic(IBookingStageRepository bookingStageRepository)
        {
            this.bookingStageRepository = bookingStageRepository;
        }

        public BookingStage AddBookingStage(BookingStage stage)
        {
            var booking = this.bookingRepository.GetById(stage.AsociatedBookingId);
            if (booking != null)
            {
                var newStage = this.bookingStageRepository.Add(stage);
                return newStage;
            }
            throw new BookingNotFoundException();
        }

        public BookingStage GetCurrentStatusByBooking(int bookingId)
        {
            var bookingStages = this.bookingStageRepository.GetByBooking(bookingId);
            BookingStage bookingStage = GetCurrentStatus(bookingStages);
            return bookingStage;
            
        }
        private BookingStage GetCurrentStatus(IEnumerable<BookingStage> bookingStages)
        {
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = -1;
            foreach (BookingStage bs in bookingStages)
            {
                if (bs.Id > bookingStage.Id)
                {
                    bookingStage = bs;
                }
            }
            return bookingStage;
        }
    }
}

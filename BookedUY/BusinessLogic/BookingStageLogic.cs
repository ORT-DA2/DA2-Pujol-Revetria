using BusinessLogicInterface;
using DataAccess.Repositories;
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
        private readonly IRepository<Booking> bookingRepository;

        public BookingStageLogic(IBookingStageRepository bookingStageRepository, IRepository<Booking> bookingRepository)
        {
            this.bookingStageRepository = bookingStageRepository;
            this.bookingRepository = bookingRepository;
        }

        public BookingStage AddBookingStage(BookingStage stage)
        {
            var booking = this.bookingRepository.GetById(stage.AsociatedBookingId);
            if (booking == null)
            {
                throw new NotFoundException("Booking");
            }
            return this.bookingStageRepository.Add(stage);
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

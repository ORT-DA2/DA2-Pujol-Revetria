using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BookingStageLogic : IBookingStageLogic
    {
        private readonly IBookingStageRepository bookingStageRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly IAdministratorRepository administratorRepository;

        public BookingStageLogic(IBookingStageRepository bookingStageRepository, IBookingRepository bookingRepository, IAdministratorRepository administratorRepository)
        {
            this.bookingStageRepository = bookingStageRepository;
            this.bookingRepository = bookingRepository;
            this.administratorRepository = administratorRepository;
        }

        public BookingStage AddBookingStage(BookingStage stage)
        {
            CheckBookingStageAsociatedBookingId(stage.AsociatedBookingId);
            var booking = this.bookingRepository.GetById(stage.AsociatedBookingId);
            CheckBookingStageAsociatedBooking(booking);
            var administrator = this.administratorRepository.GetById(stage.AdministratorId);
            CheckBookingStageAdministrator(administrator);
            return this.bookingStageRepository.Add(stage);
        }

        private void CheckBookingStageAdministrator(Administrator administrator)
        {
            if (administrator == null)
            {
                throw new NotFoundException("BookingStage Admin");
            }
        }

        private void CheckBookingStageAsociatedBooking(Booking booking)
        {
            if (booking == null)
            {
                throw new NotFoundException("BookingStage Booking");
            }
        }

        private void CheckBookingStageAsociatedBookingId(int id)
        {
            if (id == 0)
            {
                throw new NullInputException("BookingStage Booking");
            }
        }

        public BookingStage GetCurrentStatusByBooking(int bookingId)
        {
            var bookingStages = this.bookingStageRepository.GetByBooking(bookingId);
            BookingStage bookingStage = GetCurrentStatus(bookingStages);
            return bookingStage;
        }

        private BookingStage GetCurrentStatus(IEnumerable<BookingStage> bookingStages)
        {
            return bookingStages.OrderByDescending(b => b.Id).First();
        }
    }
}
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IAccommodationRepository accommodationRepository;
        private readonly ITouristRepository touristRepository;
        private readonly ITouristicSpotRepository touristicSpotRepository;

        public BookingLogic(IBookingRepository bookingRepository, IAccommodationRepository accommodationRepository, ITouristRepository touristRepository, ITouristicSpotRepository touristicSpotRepository)
        {
            this.bookingRepository = bookingRepository;
            this.accommodationRepository = accommodationRepository;
            this.touristRepository = touristRepository;
            this.touristicSpotRepository = touristicSpotRepository;
        }

        

        public Booking AddBooking(Booking booking)
        {
            CheckBookingGuests(booking);
            CheckBookingAccommodation(booking);
            var accommodation = this.accommodationRepository.GetById(booking.AccommodationId);
            var tourist = this.touristRepository.GetByEmail(booking.HeadGuest.Email);
            if (tourist != null)
            {
                booking.HeadGuest = tourist;
            }
            double totalprice = CalculateTotalPrice(booking);
            booking.TotalPrice = totalprice * accommodation.PricePerNight;
            booking.BookingHistory = new List<BookingStage>();
            BookingStage bookingStage = new BookingStage()
            {
                AdministratorId = 1,
                Status = Status.Received,
                Description = "Received"
            };
            booking.BookingHistory.Add(bookingStage);
            var newBooking = this.bookingRepository.AddAndSave(booking);
            return newBooking;
        }

        private double CalculateTotalPrice(Booking booking)
        {
            double total = 0;
            foreach (Guest guest in booking.Guests)
            {
                total += guest.GetAmount();
            }
            return total;
        }

        public IEnumerable<Booking> GetAll()
        {
            return this.bookingRepository.GetAll();
        }

        public Booking GetById(int id)
        {
            var booking = this.bookingRepository.GetById(id);
            CheckBooking(booking);
            return booking;
        }

        public List<ReportTupleReturn> GetReport(string touristicSpotName, DateTime start, DateTime end)
        {
            var touristicSpot = this.touristicSpotRepository.GetByName(touristicSpotName);
            CheckBookingTouristicSpot(touristicSpot);
            var ret = bookingRepository.GetReport(touristicSpot.Id, start, end);
            if (ret == null || ret.Count() == 0)
            {
                throw new FailedReportException();
            }
            var listOfTuple = new List<ReportTupleReturn>();
            for (int i = 0; i < ret.Count(); i++)
            {
                ReportTupleReturn reportTupleReturn = new ReportTupleReturn()
                {
                    AccommodationName = accommodationRepository.GetById(ret.ElementAt(i).Id).Name,
                    Count = ret.ElementAt(i).Count
                };
                listOfTuple.Add(reportTupleReturn);
            }
            return listOfTuple;
        }

        private void CheckBookingGuests(Booking booking)
        {
            if (booking.Guests == null)
            {
                throw new NullInputException("Booking Guests");
            }
        }

        private void CheckBookingAccommodation(Booking booking)
        {
            if (booking.AccommodationId == 0)
            {
                throw new NullInputException("Booking Accommodation");
            }
            var accommodation = this.accommodationRepository.GetById(booking.AccommodationId);
            if (accommodation == null)
            {
                throw new NotFoundException("Booking Accommodation");
            }
        }

        private void CheckBooking(Booking booking)
        {
            if (booking == null)
            {
                throw new NotFoundException("Booking");
            }
        }

        private void CheckBookingTouristicSpot(TouristicSpot touristicSpot)
        {
            if (touristicSpot == null)
            {
                throw new NotFoundException("Touristic Spot");
            }
        }
    }
}
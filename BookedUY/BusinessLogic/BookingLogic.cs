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
            if (booking.Guests == null)
            {
                throw new NullInputException("Booking Guests");
            }
            if (booking.AccommodationId == 0)
            {
                throw new NullInputException("Booking Accommodation");
            }
            
            var accommodation = this.accommodationRepository.GetById(booking.AccommodationId);
            if (accommodation == null)
            {
                throw new NotFoundException("Booking Accommodation");
            }
            var tourist = this.touristRepository.GetByEmail(booking.HeadGuest.Email);
            if (tourist != null)
            {
                booking.HeadGuest = tourist;
            }
            double totalprice = CalculateTotalPrice(booking);
            booking.TotalPrice = totalprice*accommodation.PricePerNight;
            var newBooking = this.bookingRepository.Add(booking);
            return newBooking;
        }

        private double CalculateTotalPrice(Booking booking)
        {
            double total = 0;
            foreach (Guest guest in booking.Guests)
            {
                if (guest.Multiplier == 0.70)
                {
                    int amount = guest.Amount;
                    int aux = amount - (amount / 2);
                    total += ((amount / 2) * guest.Multiplier) + aux;
                }
                else
                {
                    total += guest.Amount * guest.Multiplier;
                }
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
            if (booking == null)
            {
                throw new NotFoundException("Booking");
            }
            return booking;
        }

        public List<ReportTupleReturn> GetReport(string touristicSpotName, DateTime start, DateTime end)
        {
            var touristicSpot = this.touristicSpotRepository.GetByName(touristicSpotName);
            if(touristicSpot == null)
            {
                throw new NotFoundException("Touristic Spot");
            }
            var ret = bookingRepository.GetReport(touristicSpot.Id, start, end);
            if(ret == null || ret.Count() == 0)
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
    }
}
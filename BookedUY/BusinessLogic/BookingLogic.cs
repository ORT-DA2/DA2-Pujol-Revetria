﻿using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IRepository<Booking> bookingRepository;

        public BookingLogic(IRepository<Booking> bookingRepository)
        {
            this.bookingRepository = bookingRepository;
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
            double totalprice = CalculateTotalPrice(booking);
            booking.TotalPrice = totalprice;
            var newBooking = this.bookingRepository.Add(booking);
            return newBooking;
        }

        private double CalculateTotalPrice(Booking booking)
        {
            double total = 0;
            foreach (Guest guest in booking.Guests)
            {
                total += guest.Amount * guest.Multiplier;
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
    }
}
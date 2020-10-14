using Domain;
using System;
using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class BookingModelIn
    {
        public int AccommodationId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestLastName { get; set; }
        public List<Guest> Guests { get; set; }

        public Booking FromModelInToBooking()
        {
            Tourist g = new Tourist()
            {
                Name = GuestName,
                Email = GuestEmail,
                LastName = GuestLastName
            };
            Booking booking = new Booking()
            {
                AccommodationId = this.AccommodationId,
                CheckIn = this.CheckIn,
                CheckOut = this.CheckOut,
                HeadGuest = g,
                Guests = Guests
            };
            return booking;
        }
    }
}
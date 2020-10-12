using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class BookingModelOut
    {
        public int Id { get; set; }
        public int AccommodationId { get; set; }
        public string AccommodationName { get; set; }
        public string AccommodationAddress { get; set; }
        public string AccommodationContact { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Price { get; set; }
        public string GuestEmail { get; set; }

        public BookingModelOut(Booking b)
        {
            Id = b.Id;
            AccommodationId = b.AccommodationId;
            AccommodationName = b.Accommodation.Name;
            AccommodationAddress = b.Accommodation.Address;
            AccommodationContact = b.Accommodation.ContactNumber;
            CheckIn = b.CheckIn;
            CheckOut = b.CheckOut;
            Price = b.TotalPrice;
            GuestEmail = b.HeadGuest.Email;
        }
    }
}

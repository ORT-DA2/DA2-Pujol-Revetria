using System;
using System.Collections.Generic;

namespace Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public Accommodation Accommodation { get; set; }
        public int AccommodationId { get; set; }
        private DateTime _checkIn;

        public DateTime CheckIn
        {
            get
            {
                return _checkIn.Date;
            }
            set
            {
                if (value.Date < DateTime.Now.Date)
                {
                    throw new InvalidDateException("CheckIn");
                }
                else
                {
                    _checkIn = value.Date;
                }
            }
        }

        private DateTime _checkOut;

        public DateTime CheckOut
        {
            get
            {
                return _checkOut;
            }
            set
            {
                if (value.Date < DateTime.Now.Date || value.Date < CheckIn)
                {
                    throw new InvalidDateException("CheckOut");
                }
                else
                {
                    _checkOut = value.Date;
                }
            }
        }

        public double TotalPrice { get; set; }
        public List<Guest> Guests { get; set; }
        public Tourist HeadGuest { get; set; }
        public int GuestId { get; set; }
        public Review Rating { get; set; }
        public List<BookingStage> BookingHistory { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Booking booking)
            {
                result = this.Id == booking.Id;
            }
            return result;
        }
    }
}
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

        public Booking()
        {
        }

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

        public override int GetHashCode()
        {
            int hashCode = -521319978;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Accommodation>.Default.GetHashCode(Accommodation);
            hashCode = hashCode * -1521134295 + AccommodationId.GetHashCode();
            hashCode = hashCode * -1521134295 + _checkIn.GetHashCode();
            hashCode = hashCode * -1521134295 + CheckIn.GetHashCode();
            hashCode = hashCode * -1521134295 + _checkOut.GetHashCode();
            hashCode = hashCode * -1521134295 + CheckOut.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Guest>>.Default.GetHashCode(Guests);
            hashCode = hashCode * -1521134295 + EqualityComparer<Tourist>.Default.GetHashCode(HeadGuest);
            hashCode = hashCode * -1521134295 + GuestId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Review>.Default.GetHashCode(Rating);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BookingStage>>.Default.GetHashCode(BookingHistory);
            return hashCode;
        }
    }
}
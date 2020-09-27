using System;
using System.Collections.Generic;

namespace Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public Accommodation Accommodation { get; set; }
        public int AccommodationId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float TotalPrice { get; set; }
        public List<Guest> Guests {get; set;}
        public Tourist HeadGuest { get; set; }
        public int GuestId { get; set; }
        public List<BookingStage> BookingHistory { get; set; }
    }
}

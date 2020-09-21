using System;
using System.Collections.Generic;

namespace Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float TotalPrice { get; set; }
        public int BabyGuests { get; set; }
        public int ChildGuests { get; set; }
        public int AdultGuests { get; set; }
        public Tourist Guest { get; set; }
        public List<BookingStage> BookingHistory { get; set; }
    }
}

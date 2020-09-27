using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Guest
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public float Multiplier { get; set; }

        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}

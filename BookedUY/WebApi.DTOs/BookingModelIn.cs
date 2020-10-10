using Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Guest[] Guests { get; set; }
    }
}

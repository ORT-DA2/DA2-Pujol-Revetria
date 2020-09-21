using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookingStage
    {
        public int Id { get; set; }
        public Administrator Administrator { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public Booking AsociatedBooking { get; set; }
    }
}

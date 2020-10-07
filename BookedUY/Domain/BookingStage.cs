using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookingStage
    {
        public int Id { get; set; }
        public User Administrator { get; set; }
        public int AdministratorId { get; set; }

        public Status Status { get; set; }
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _description = value.Trim();
                }
            }
        }
        public DateTime EntryDate { get; set; }
        public Booking AsociatedBooking { get; set; }
        public int AsociatedBookingId { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is BookingStage bookingStage)
            {
                result = this.Id == bookingStage.Id;
            }
            return result;
        }
    }
}

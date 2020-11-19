using System;
using System.Collections.Generic;

namespace Domain
{
    public class BookingStage
    {
        public int Id { get; set; }
        public Administrator Administrator { get; set; }
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
                    throw new NullInputException("Booking Stage Description");
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

        public override int GetHashCode()
        {
            int hashCode = -1349910579;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Administrator>.Default.GetHashCode(Administrator);
            hashCode = hashCode * -1521134295 + AdministratorId.GetHashCode();
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EntryDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Booking>.Default.GetHashCode(AsociatedBooking);
            hashCode = hashCode * -1521134295 + AsociatedBookingId.GetHashCode();
            return hashCode;
        }
    }
}
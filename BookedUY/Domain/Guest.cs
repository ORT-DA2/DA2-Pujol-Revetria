using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Guest
    {
        public int Id { get; set; }
        private int _amount;
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeAmountException();
                }
                else
                {
                    _amount = value;
                }
            }
        }
        public double Multiplier { get; set; }

        public Booking Booking { get; set; }
        public int BookingId { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Guest guest)
            {
                result = this.Id == guest.Id;
            }
            return result;
        }
    }
}

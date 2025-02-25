﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
                    throw new NegativeAmountException("Guest Amount");
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
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            int hashCode = -1488041194;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + _amount.GetHashCode();
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + Multiplier.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Booking>.Default.GetHashCode(Booking);
            hashCode = hashCode * -1521134295 + BookingId.GetHashCode();
            return hashCode;
        }

        public double GetAmount()
        {
            if (Multiplier == 0.70)
            {
                int amount = Amount;
                int aux = amount - (amount / 2);
                return (double)((amount / 2) * Multiplier) + aux;
            }
            else
            {
                return (double)(Amount * Multiplier);
            }
        }
    }
}
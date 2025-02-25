﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Accommodation
    {
        public int Id { get; set; }
        public TouristicSpot Spot { get; set; }
        public int SpotId { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException("Accommodation Name");
                }
                else
                {
                    _name = value.Trim();
                }
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException("Accommodation Address");
                }
                else
                {
                    _address = value.Trim();
                }
            }
        }

        private string _contactNumber;

        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException("Accommodation Contact");
                }
                else
                {
                    _contactNumber = value.Trim();
                }
            }
        }

        private string _information;

        public string Information
        {
            get
            {
                return _information;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException("Accommodation Info");
                }
                else
                {
                    _information = value.Trim();
                }
            }
        }

        private double _pricePerNight;

        public double PricePerNight
        {
            get
            {
                return _pricePerNight;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativePriceException("Price per Night");
                }
                else
                {
                    _pricePerNight = value;
                }
            }
        }

        public bool Full { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<AccommodationImage> Images { get; set; }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Accommodation accommodation)
            {
                result = this.Id == accommodation.Id && this.Name == accommodation.Name;
            }
            return result;
        }
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            int hashCode = 671208328;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TouristicSpot>.Default.GetHashCode(Spot);
            hashCode = hashCode * -1521134295 + SpotId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_contactNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContactNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_information);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Information);
            hashCode = hashCode * -1521134295 + _pricePerNight.GetHashCode();
            hashCode = hashCode * -1521134295 + PricePerNight.GetHashCode();
            hashCode = hashCode * -1521134295 + Full.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Booking>>.Default.GetHashCode(Bookings);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<AccommodationImage>>.Default.GetHashCode(Images);
            return hashCode;
        }
    }
}
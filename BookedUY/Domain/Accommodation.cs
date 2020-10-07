using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Accommodation
    {
        public int Id { get; set; }
        public TouristicSpot Spot{ get; set; }
        public int SpotId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
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
                    throw new NullInputException();
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
                    throw new NullInputException();
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
                    throw new NullInputException();
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
                    throw new NegativePriceException();
                }
                else
                {
                    _pricePerNight = value;
                }
            }
        }
        public bool Full { get; set; }
        public List<Booking> Bookings{ get; set;}

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
    }
}

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
                    throw new Exception("Name cannot be empty");
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
                    throw new Exception("Address cannot be empty");
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
                    throw new Exception("Name cannot be empty");
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
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    _information = value.Trim();
                }
            }
        }
        private float _pricePerNight;
        public float PricePerNight
        {
            get
            {
                return _pricePerNight;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Price must be positive");
                }
                else
                {
                    _pricePerNight = value;
                }
            }
        }
        public bool Full { get; set; }
        public List<Booking> Bookings{ get; set;}

    }
}

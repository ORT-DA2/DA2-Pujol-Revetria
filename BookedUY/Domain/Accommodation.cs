using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Accommodation
    {
        public int Id { get; set; }
        public TouristicSpot Spot { get; set; }
        public int SpotId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Information { get; set; }
        public float PricePerNight { get; set; }
        public bool Full { get; set; }
        public List<Booking> Bookings { get; set; }

        public Accommodation(int id, TouristicSpot spot, string name, string address, string contactNumber, string information, float pricePerNight)
        {
            Id = id;
            Spot = spot;
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
            Information = information;
            PricePerNight = pricePerNight;
            Full = false;
            Bookings = new List<Booking>();
            SpotId = spot.Id;
        }
    }
}

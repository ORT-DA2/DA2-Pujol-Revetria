using Domain;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace WebApi.DTOs
{
    public class AccommodationModelIn
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string Contact { get; set; }
        public string Information { get; set; }
        public int SpotId { get; set; }

        public Accommodation FromModelInToAccommodation()
        {
            Accommodation accommodation = new Accommodation()
            {
                Name = Name,
                Address = Address,
                PricePerNight = Price,
                ContactNumber = Contact,
                Information = Information,
                SpotId = SpotId
            };
            return accommodation;
        }
    }
}

using Domain;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
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
        public string[] Images { get; set; }

        public Accommodation FromModelInToAccommodation()
        {
            List<AccommodationImage> images = new List<AccommodationImage>();
            for (int i = 0; i < Images.Length; i++)
            {
                images.Add(new AccommodationImage()
                {
                    Image = Images[i]
                });
            }
            Accommodation accommodation = new Accommodation()
            {
                Name = Name,
                Address = Address,
                PricePerNight = Price,
                ContactNumber = Contact,
                Information = Information,
                SpotId = SpotId,
                Images = images
            };
            return accommodation;
        }
    }
}

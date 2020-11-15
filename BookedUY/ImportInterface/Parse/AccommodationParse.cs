using System;
using System.Collections.Generic;
using System.Text;

namespace ImportInterface.Parse
{
    public class AccommodationParse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Information { get; set; }
        public double PricePerNight { get; set; }
        public bool Full { get; set; }
        public List<AccommodationImageParse> Images { get; set; }
        public string Description { get; set; }
        public TouristicSpotParse TouristicSpot { get; set; }
        //Todos loas atributos necesarios
    }
}

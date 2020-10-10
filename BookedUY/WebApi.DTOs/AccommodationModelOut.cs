using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class AccommodationModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Information { get; set; }
        public double Price { get; set; }
        public string SpotName { get; set; }
    }
}

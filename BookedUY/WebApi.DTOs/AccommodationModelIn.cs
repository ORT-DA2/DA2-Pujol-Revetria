using System;
using System.Collections.Generic;
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
    }
}

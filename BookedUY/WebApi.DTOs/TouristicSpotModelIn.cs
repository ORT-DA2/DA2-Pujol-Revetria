using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class TouristicSpotModelIn
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
    }
}

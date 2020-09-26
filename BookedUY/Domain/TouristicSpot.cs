using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicSpot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
        public List<CategoryTouristicSpot> Categories { get; set; }
        public List<Accommodation> Accommodations { get; set; }
    }
}

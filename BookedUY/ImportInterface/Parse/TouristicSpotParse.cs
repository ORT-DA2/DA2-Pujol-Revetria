using System;
using System.Collections.Generic;
using System.Text;

namespace ImportInterface.Parse
{
    public class TouristicSpotParse
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
        public List<int> Categories { get; set; }
        public string Image { get; set; }
    }
}

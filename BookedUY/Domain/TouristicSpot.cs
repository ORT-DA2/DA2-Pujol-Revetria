using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicSpot
    {
        string Name { get; set; }
        Region Region { get; set; }
        string Description { get; set; }
        List<Category> Categories { get; set; }
    }
}

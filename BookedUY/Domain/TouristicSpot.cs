using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

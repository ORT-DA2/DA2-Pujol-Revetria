using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Region
    {
        string Name { get; set; }
        List<TouristicSpot> Spots { get; set; }
    }
}

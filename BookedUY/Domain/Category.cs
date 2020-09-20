using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category
    {
        string Name { get; set; }
        List<TouristicSpot> Spots { get; set; }
    }
}

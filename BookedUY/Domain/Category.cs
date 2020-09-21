using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category
    {
        public string Name { get; set; }
        public List<TouristicSpot> Spots { get; set; }
    }
}

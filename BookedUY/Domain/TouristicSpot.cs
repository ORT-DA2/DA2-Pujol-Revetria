﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicSpot
    {
        public string Name { get; set; }
        public Region Region { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public List<Accommodation> Accommodations { get; set; }
    }
}

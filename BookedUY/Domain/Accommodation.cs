using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Accommodation
    {
        TouristicSpot Spot { get; set; }
        string Name { get; set; }
        string Addres { get; set; }
        string ContactNumber { get; set; }
        string Information { get; set; }
        float PricePerNight { get; set; }
        bool Full { get; set; }
        List<Booking> Bookings { get; set; }
    }
}

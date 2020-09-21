using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Tourist
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}

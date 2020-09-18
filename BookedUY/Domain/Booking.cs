using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Booking
    {
        int Id { get; set; }
        Accommodation Accommodation { get; set; }
        DateTime CheckIn { get; set; }
        DateTime CheckOut { get; set; }
        float TotalPrice { get; set; }
        int[] Guests { get; set; }
        string HostName { get; set; }
        string HostLastName { get; set; }
        string HostEmail { get; set; }
        List<BookingStage> BookingStage { get; set; }
        
    }
}

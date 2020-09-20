using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Administrator
    {
        string Email { get; set; }
        string Password { get; set; }

        List<BookingStage> Entries { get; set; }
    }
}

using System;

namespace Domain
{
    public class BookingStage
    {
        Administrator Administrator { get; set; }
        Status Status { get; set; }
        string Description { get; set; }
        DateTime EntryDate { get; set; }
    }
}
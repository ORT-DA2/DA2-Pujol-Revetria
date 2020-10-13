using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class BookingStageModelOut
    {
        public string Description { get; set; }
        public string Status { get; set; }

        public BookingStageModelOut(BookingStage b)
        {
            Description = b.Description;
            Status = b.Status.ToString();
        }
    }
}

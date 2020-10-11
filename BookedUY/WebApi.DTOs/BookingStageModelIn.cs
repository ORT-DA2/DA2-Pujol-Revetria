using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class BookingStageModelIn
    {
        public int BookingId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int AdminId { get; set; }
    }
}

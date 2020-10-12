using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class BookingStageModelOut
    {
        public string Descripcion { get; set; }
        public string Status { get; set; }

        public BookingStageModelOut(BookingStage b)
        {
            Descripcion = b.Descripcion;
            Status = b.Status;
        }
    }
}

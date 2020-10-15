using Domain;

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
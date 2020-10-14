using Domain;

namespace WebApi.DTOs
{
    public class BookingStageModelIn
    {
        public int BookingId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int AdminId { get; set; }

        public BookingStage FromModelInToBookingStage()
        {
            BookingStage bookingStage = new BookingStage()
            {
                AsociatedBookingId = this.BookingId,
                Description = this.Description,
                Status = StatusMethods.StringToStatus(this.Status),
                AdministratorId = this.AdminId
            };
            return bookingStage;
        }
    }
}
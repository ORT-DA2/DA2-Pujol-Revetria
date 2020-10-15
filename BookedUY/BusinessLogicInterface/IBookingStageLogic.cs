using Domain;

namespace BusinessLogicInterface
{
    public interface IBookingStageLogic
    {
        BookingStage AddBookingStage(BookingStage stage);

        BookingStage GetCurrentStatusByBooking(int bookingId);
    }
}
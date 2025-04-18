using RoomBookingAPI.DTOs.Booking;

namespace RoomBookingAPI.Contracts.Services;

public interface IBookingService
{
    Task CreateAsync(CreateBookingDto bookingDto);
}

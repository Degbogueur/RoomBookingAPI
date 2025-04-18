using RoomBookingAPI.DTOs.Booking;

namespace RoomBookingAPI.Contracts.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<BookingDto>> GetAllAsync();
    Task<BookingDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateBookingDto bookingDto);
    Task UpdateAsync(int id, UpdateBookingDto bookingDto);
    Task DeleteAsync(int id);
}

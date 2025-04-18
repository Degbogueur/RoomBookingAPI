using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.Contracts.Services;
using RoomBookingAPI.DTOs.Booking;

namespace RoomBookingAPI.Services;

public class BookingService(
    IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    public async Task CreateAsync(CreateBookingDto bookingDto)
    {
        if (bookingDto.StartDate >= bookingDto.EndDate)
        {
            throw new ArgumentException("Start date must be before end date.");
        }

        await _bookingRepository.CreateAsync(bookingDto);
    }
}

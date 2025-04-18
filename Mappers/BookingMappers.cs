using RoomBookingAPI.DTOs.Booking;
using RoomBookingAPI.Models;

namespace RoomBookingAPI.Mappers;

public static class BookingMappers
{
    public static BookingDto ToDto(this Booking booking)
    {
        return new BookingDto
        {
            Id = booking.Id,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            RoomName = booking.Room?.Name ?? string.Empty,
            UserFullName = booking.User?.FullName ?? string.Empty
        };
    }

    public static Booking ToModel(this CreateBookingDto createBookingDto)
    {
        return new Booking
        {
            RoomId = createBookingDto.RoomId,
            UserId = createBookingDto.UserId,
            StartDate = createBookingDto.StartDate,
            EndDate = createBookingDto.EndDate
        };
    }

    public static Booking ToModel(this UpdateBookingDto updateBookingDto, int id)
    {
        return new Booking
        {
            Id = id,
            RoomId = updateBookingDto.RoomId,
            UserId = updateBookingDto.UserId,
            StartDate = updateBookingDto.StartDate,
            EndDate = updateBookingDto.EndDate
        };
    }
}

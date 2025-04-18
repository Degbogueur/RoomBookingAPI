using Microsoft.EntityFrameworkCore;
using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.Data;
using RoomBookingAPI.DTOs.Booking;
using RoomBookingAPI.Mappers;

namespace RoomBookingAPI.Repositories;

public class BookingRepository(
    ApplicationDbContext context) : IBookingRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(CreateBookingDto bookingDto)
    {
        var booking = bookingDto.ToModel();

        if (await IsRoomAvailable(booking.RoomId, booking.StartDate, booking.EndDate))
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Room is not available for the selected dates.");
        }
    }    

    public async Task DeleteAsync(int id)
    {
        var booking = await _context.Bookings.FindAsync(id)
            ?? throw new ArgumentNullException($"Booking with ID {id} not found.");

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Select(booking => booking.ToDto())
            .ToListAsync();
    }

    public async Task<BookingDto?> GetByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Where(booking => booking.Id == id)
            .Select(booking => booking.ToDto())
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(int id, UpdateBookingDto bookingDto)
    {
        var existingBooking = await _context.Bookings.FindAsync(id)
            ?? throw new ArgumentNullException($"Booking with ID {id} not found.");

        var updatedBooking = bookingDto.ToModel(id);
        _context.Entry(existingBooking).CurrentValues.SetValues(updatedBooking);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate)
    {
        return !await _context.Bookings
            .AnyAsync(b => b.RoomId == roomId
                        && b.StartDate < endDate && b.EndDate > startDate);
    }
}

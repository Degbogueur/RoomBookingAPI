using Microsoft.EntityFrameworkCore;
using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.Data;
using RoomBookingAPI.DTOs.Room;
using RoomBookingAPI.Mappers;

namespace RoomBookingAPI.Repositories;

public class RoomRepository(
    ApplicationDbContext context) : IRoomRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(CreateRoomDto roomDto)
    {
        var room = roomDto.ToModel();
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id) 
            ?? throw new ArgumentNullException($"Room with ID {id} not found.");

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoomDto>> GetAllAsync()
    {
        return await _context.Rooms
            .Select(room => room.ToDto())
            .ToListAsync();
    }

    public async Task<RoomDto?> GetByIdAsync(int id)
    {
        return await _context.Rooms
            .Where(room => room.Id == id)
            .Select(room => room.ToDto())
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(int id, UpdateRoomDto roomDto)
    {
        var existingRoom = await _context.Rooms.FindAsync(id)
            ?? throw new ArgumentNullException($"Room with ID {id} not found.");

        var updatedRoom = roomDto.ToModel(id);
        _context.Entry(existingRoom).CurrentValues.SetValues(updatedRoom);
        //_context.Entry(existingRoom).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.Data;
using RoomBookingAPI.DTOs.User;
using RoomBookingAPI.Exceptions;
using RoomBookingAPI.Mappers;

namespace RoomBookingAPI.Repositories;

public class UserRepository(
    ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(CreateUserDto userDto)
    {
        var user = userDto.ToModel();

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id)
            ?? throw new NotFoundException(id);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return await _context.Users
            .Select(user => user.ToDto())
            .ToListAsync();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        return await _context.Users
            .Where(user => user.Id == id)
            .Select(user => user.ToDto())
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(int id, UpdateUserDto userDto)
    {
        var existingUser = await _context.Users.FindAsync(id)
            ?? throw new NotFoundException(id);

        var updatedUser = userDto.ToModel(id);
        _context.Entry(existingUser).CurrentValues.SetValues(updatedUser);
        await _context.SaveChangesAsync();
    }
}
using RoomBookingAPI.DTOs.User;

namespace RoomBookingAPI.Contracts.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateUserDto userDto);
    Task UpdateAsync(int id, UpdateUserDto userDto);
    Task DeleteAsync(int id);
}

using RoomBookingAPI.DTOs.Room;

namespace RoomBookingAPI.Contracts.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<RoomDto>> GetAllAsync();
    Task<RoomDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateRoomDto roomDto);
    Task UpdateAsync(int id, UpdateRoomDto roomDto);
    Task DeleteAsync(int id);
}

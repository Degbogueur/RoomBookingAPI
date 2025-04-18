using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.Contracts.Services;
using RoomBookingAPI.DTOs.Room;

namespace RoomBookingAPI.Services;

public class RoomService(
    IRoomRepository roomRepository) : IRoomService
{
    private readonly IRoomRepository _roomRepository = roomRepository;

    public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync(int minCapacity)
    {
        var rooms = await _roomRepository.GetAllAsync();
        return rooms.Where(r => r.Capacity >= minCapacity);
    }
}

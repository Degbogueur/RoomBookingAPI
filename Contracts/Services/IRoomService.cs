using RoomBookingAPI.DTOs.Room;

namespace RoomBookingAPI.Contracts.Services;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync(int minCapacity);
}

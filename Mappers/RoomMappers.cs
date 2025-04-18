using RoomBookingAPI.DTOs.Room;
using RoomBookingAPI.Models;

namespace RoomBookingAPI.Mappers;

public static class RoomMappers
{
    public static RoomDto ToDto(this Room room)
    {
        return new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity
        };
    }

    public static Room ToModel(this CreateRoomDto roomDto)
    {
        return new Room
        {
            Name = roomDto.Name,
            Capacity = roomDto.Capacity
        };
    }

    public static Room ToModel(this UpdateRoomDto roomDto, int id)
    {
        return new Room
        {
            Id = id,
            Name = roomDto.Name,
            Capacity = roomDto.Capacity
        };
    }
}

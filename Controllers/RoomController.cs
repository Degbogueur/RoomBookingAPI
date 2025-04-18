using Microsoft.AspNetCore.Mvc;
using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.Contracts.Services;
using RoomBookingAPI.DTOs.Room;

namespace RoomBookingAPI.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomController(
    IRoomRepository roomRepository,
    IRoomService roomService) : ControllerBase
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    private readonly IRoomService _roomService = roomService;

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _roomRepository.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto roomDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _roomRepository.CreateAsync(roomDto);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomDto roomDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _roomRepository.UpdateAsync(id, roomDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        await _roomRepository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableRooms([FromQuery] int minCapacity)
    {
        var availableRooms = await _roomService.GetAvailableRoomsAsync(minCapacity);
        return Ok(availableRooms);
    }
}

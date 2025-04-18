using Microsoft.AspNetCore.Mvc;
using RoomBookingAPI.Contracts.Repositories;
using RoomBookingAPI.DTOs.Booking;

namespace RoomBookingAPI.Controllers;

[Route("api/bookings")]
[ApiController]
public class BookingController(
    IBookingRepository bookingRepository) : ControllerBase
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingRepository.GetAllAsync();
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto bookingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _bookingRepository.CreateAsync(bookingDto);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingDto bookingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _bookingRepository.UpdateAsync(id, bookingDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        await _bookingRepository.DeleteAsync(id);
        return NoContent();
    }
}

using System.ComponentModel.DataAnnotations;

namespace RoomBookingAPI.DTOs.Booking;

public class BaseBookingDto
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}

public class BookingDto : BaseBookingDto
{
    public int Id { get; set; }
    public string RoomName { get; set; } = null!;
    public string UserFullName { get; set; } = null!;
}

public class CreateBookingDto : BaseBookingDto
{
    [Required]
    public int RoomId { get; set; }
    [Required]
    public int UserId { get; set; }
}

public class UpdateBookingDto : BaseBookingDto
{
    [Required]
    public int RoomId { get; set; }
    [Required]
    public int UserId { get; set; }
}

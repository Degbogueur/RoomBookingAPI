using System.ComponentModel.DataAnnotations;

namespace RoomBookingAPI.DTOs.Room;

public class BaseRoomDto
{
    [Required(ErrorMessage = "Room name is required.")]
    [StringLength(20, ErrorMessage = "Room name cannot exceed {1} characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Room capacity is required.")]
    [Range(10, 100, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Capacity { get; set; }
}

public class RoomDto : BaseRoomDto
{
    public int Id { get; set; }
}

public class CreateRoomDto : BaseRoomDto
{
}

public class UpdateRoomDto : BaseRoomDto
{
}

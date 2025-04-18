using System.ComponentModel.DataAnnotations;

namespace RoomBookingAPI.DTOs.User;

public class BaseUserDto
{
    public string FullName { get; set; } = null!;
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;
}

public class UserDto : BaseUserDto
{
    public int Id { get; set; }
}

public class CreateUserDto : BaseUserDto
{
}

public class UpdateUserDto : BaseUserDto
{
}
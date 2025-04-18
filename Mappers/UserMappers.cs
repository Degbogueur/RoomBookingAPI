using RoomBookingAPI.DTOs.User;
using RoomBookingAPI.Models;

namespace RoomBookingAPI.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };
        }

        public static User ToModel(this CreateUserDto createUserDto)
        {
            return new User
            {
                FullName = createUserDto.FullName,
                Email = createUserDto.Email
            };
        }

        public static User ToModel(this UpdateUserDto updateUserDto, int id)
        {
            return new User
            {
                Id = id,
                FullName = updateUserDto.FullName,
                Email = updateUserDto.Email
            };
        }
    }
}

using System.Net;

namespace RoomBookingAPI.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string? message)
        : base(
              message: $"Requête erronée{(!string.IsNullOrWhiteSpace(message) ? $": {message}" : string.Empty)}",
              title: "Bad Request Error",
              statusCode: HttpStatusCode.BadRequest)
    {            
    }
}

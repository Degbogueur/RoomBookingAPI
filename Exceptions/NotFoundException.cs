using System.Net;

namespace RoomBookingAPI.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(int id)
        : base(
            message: $"Entity with id {id} not found", 
            title: "Not Found Error",
            statusCode: HttpStatusCode.NotFound)
    {
    }
}

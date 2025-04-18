using System.Net;

namespace RoomBookingAPI.Exceptions;

public class BaseException : Exception
{
    public string Title { get; set; } = null!;
    public HttpStatusCode StatusCode { get; set; }

    public BaseException(
        string message, 
        string title = "An error occured", 
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        : base(message)
    {
        Title = title;
        StatusCode = statusCode;
    }
}

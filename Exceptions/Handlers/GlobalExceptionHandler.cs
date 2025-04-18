using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RoomBookingAPI.Exceptions.Handlers;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IHostEnvironment environment) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;
    private readonly IHostEnvironment _environment = environment;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails();
        problemDetails.Instance = httpContext.Request.Path;

        if (exception is BaseException ex)
        {
            httpContext.Response.StatusCode = (int)ex.StatusCode;
            problemDetails.Title = ex.Title;
            problemDetails.Detail = ex.Message;
        }
        else
        {
            problemDetails.Title = _environment.IsDevelopment()
                                   ? exception.Message
                                   : "An error occured";
        }
        problemDetails.Status = httpContext.Response.StatusCode;

        _logger.LogError(
                exception,
                "{exception} occured at {timeStamp} from {path}",
                exception.GetType().Name, DateTime.Now, problemDetails.Instance);

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
        return true;
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoomBookingAPI.Exceptions;

namespace RoomBookingAPI.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger,
    IHostEnvironment environment)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
    private readonly IHostEnvironment _environment = environment;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = ex switch
            {
                BaseException e => (int)e.StatusCode,
                _ => StatusCodes.Status500InternalServerError
            };

            var problemDetails = new ProblemDetails
            {
                Title = ex is BaseException baseEx ? baseEx.Title : "Internal Server Error",
                Status = response.StatusCode,
                Detail = ex is BaseException || _environment.IsDevelopment()
                         ? ex.Message
                         : "An error occured"
            };

            _logger.LogError(
                ex,
                "{exception} occured at {timeStamp} from {path}",
                ex.GetType().Name, DateTime.Now, context.Request.Path);

            await response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}

namespace RoomBookingAPI.Middlewares;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;

        request.EnableBuffering(); // Enable buffering to read the request body multiple times

        var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
        request.Body.Position = 0; // Reset the stream position to allow further processing

        _logger.LogInformation("Request: {Method} {Path} at {Timestamp}", request.Method, request.Path, DateTime.Now);

        await _next(context);

        var response = context.Response;
        _logger.LogInformation("Response: {StatusCode}", response.StatusCode);
    }
}

﻿using RoomBookingAPI.Middlewares;

namespace RoomBookingAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestLoggingMiddleware>();
        return app;
    }
}

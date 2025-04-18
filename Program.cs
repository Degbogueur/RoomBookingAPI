using RoomBookingAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddExceptionHandlers();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRequestLogging();

// Remove comment to use ExceptionHandlingMiddleware for exceptions handling
//app.UseExceptionHandling();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();

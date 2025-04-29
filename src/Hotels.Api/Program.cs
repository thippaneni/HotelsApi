using Hotels.Application;
using Hotels.Application.Configuration;
using Hotels.Application.CQRS.Hotels.Commands;
using Hotels.Application.CQRS.Hotels.Queries;
using Hotels.Application.Dtos;
using Hotels.Application.Interafces;
using Hotels.Application.Middlewares;
using Hotels.Application.Services;
using Hotels.Domain.Models;
using Hotels.Infrastructure;
using MediatR;

MapperConfiguration.ConfigureMappings();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplication();

var config = builder.Configuration;
builder.Services.AddInfrastucture(config);

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var _logger = app.Services.GetRequiredService<ILogger<Program>>();

app.MapGet("/", () => "Hotels Api is ruunnig");

var hotelsGroup = app.MapGroup("/api/hotels");

// GET all hotels
hotelsGroup.MapGet("/", async (IMediator mediator) =>
{
    var hotels = await mediator.Send(new GetAllHotelsQuery());
    return Results.Ok(hotels);
});

// GET hotel by id
hotelsGroup.MapGet("/{id}", async (IHotelService hotelService, Guid id) =>
{
    _logger.LogInformation("Fetching hotel with ID: {HotelId} in Controller", id);
    try
    {
        var hotel = await hotelService.GetHotelByIdAsync(id);
        return hotel is not null ? Results.Ok(hotel) : Results.NotFound();
    }
    catch (Exception)
    {
        _logger.LogError("An error occurred while fetching the hotel with ID: {HotelId}", id);
        throw;
    }
    
});

// Create hotel
hotelsGroup.MapPost("/", async (IHotelService hotelService, Hotel hotel) =>
{
    var createdHotel = await hotelService.CreateAsync(hotel);
    return Results.Created($"/hotels/{createdHotel.Id}", createdHotel);
});

hotelsGroup.MapPost("/m", async (IMediator mediator, HotelDto hotelDto) =>
{
    var createHotelCommand = new CreateHotelCommand(hotelDto);
    var createdHotel = await mediator.Send(createHotelCommand);

    return Results.Created($"/hotels/{createdHotel.Id}", createdHotel);
});

// PUT update hotel
hotelsGroup.MapPut("/{id}", async (Hotel hotel, IHotelService hotelService) =>
{
    var updatedHotel = await hotelService.UdpateHotelAsync(hotel);
    if (updatedHotel == null)
        return Results.NotFound();

    return Results.Ok(updatedHotel);
});

// DELETE hotel
hotelsGroup.MapDelete("/{id}", async (Guid id, IHotelService hotelService) =>
{
    var result = await hotelService.DeleteHotelAsync(id);
    if (!result)
        return Results.NotFound();

    return Results.NoContent();
});


var reviewsGroup = app.MapGroup("/api/reviews");
// GET all reviews
reviewsGroup.MapGet("/hotel/{hotelId}", async (Guid hotelId, IReviewService reviewService) =>
{
    var reviews = await reviewService.GetReviewsByHotelIdAsync(hotelId);
    return Results.Ok(reviews);
});

app.Run();

using Hotels.Application;
using Hotels.Application.Interafces;
using Hotels.Application.Services;
using Hotels.Domain.Models;
using Hotels.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplication();
builder.Services.AddInfrastucture();

var config = builder.Configuration;

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", () => "Hotels Api is ruunnig");

var hotelsGroup = app.MapGroup("/api/hotels");

// GET all hotels
hotelsGroup.MapGet("/", async (IHotelService hotelService) =>
{
    var hotels = await hotelService.GetAllHOtelsAsync();
    return Results.Ok(hotels);
});

// GET hotel by id
hotelsGroup.MapGet("/{id}", async (IHotelService hotelService, Guid id) =>
{
    var hotel = await hotelService.GetHotelByIdAsync(id);
    return hotel is not null ? Results.Ok(hotel) : Results.NotFound();
});

// GET hotel by name
hotelsGroup.MapPost("/", async (IHotelService hotelService, Hotel hotel) =>
{
    var createdHotel = await hotelService.CreateAsync(hotel);
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

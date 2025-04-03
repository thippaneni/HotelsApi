using Hotels.Application;
using Hotels.Application.Interafces;
using Hotels.Application.Services;
using Hotels.Domain.Models;
using Hotels.Infrastructure;
using Microsoft.AspNetCore.Authorization;

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


app.MapGet("/hotels", async (IHotelService hotelService) =>
{
    var hotels = await hotelService.GetAllHOtelsAsync();
    return Results.Ok(hotels);
});

app.MapGet("/hotels/{id}", async (IHotelService hotelService, Guid id) =>
{
    var hotel = await hotelService.GetHotelByIdAsync(id);
    return hotel is not null ? Results.Ok(hotel) : Results.NotFound();
});

app.MapPost("/hotels", async (IHotelService hotelService, Hotel hotel) =>
{
    var createdHotel = await hotelService.CreateAsync(hotel);
    return Results.Created($"/hotels/{createdHotel.Id}", createdHotel);
});

app.MapGet("/lifecycle", (ITransientService transientService, IScopedService scopedService, ISingletonService singletonService) =>
{
    return Results.Ok(new
    {
        Transient = transientService.GetOperationId(),
        Scoped = scopedService.GetOperationId(),
        Singleton = singletonService.GetOperationId()
    });
});

app.Run();

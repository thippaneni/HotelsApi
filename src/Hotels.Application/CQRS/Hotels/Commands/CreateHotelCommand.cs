using Hotels.Application.Dtos;
using MediatR;

namespace Hotels.Application.CQRS.Hotels.Commands
{
    public record CreateHotelCommand(HotelDto hotelDto)
        : IRequest<HotelDto>;
}

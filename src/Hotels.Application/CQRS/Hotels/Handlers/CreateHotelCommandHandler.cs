using Hotels.Application.CQRS.Hotels.Commands;
using Hotels.Application.Dtos;
using Hotels.Application.Interafces;
using Hotels.Domain.Models;
using Mapster;
using MediatR;


namespace Hotels.Application.CQRS.Hotels.Handlers
{
    public class CreateHotelCommandHandler(IHotelService hotelService)
        : IRequestHandler<CreateHotelCommand, HotelDto>
    {
        public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = request.hotelDto.Adapt<Hotel>();            
            var createdHotel = await hotelService.CreateAsync(hotel);

            // domain event trigger
            //var hotelCreatedEvent = new HotelCreatedEvent(createdHotel);

            var hotelDto = createdHotel.Adapt<HotelDto>();
            return hotelDto;
        }
    }
}

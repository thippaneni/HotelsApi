using Hotels.Application.CQRS.Hotels.Queries;
using Hotels.Application.Dtos;
using Hotels.Application.Interafces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.CQRS.Hotels.Handlers
{
    public class GetAllHotelsQueryHandler(IHotelService hotelService) : IRequestHandler<GetAllHotelsQuery, IEnumerable<HotelDto>>
    {
        public async Task<IEnumerable<HotelDto>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await hotelService.GetAllHOtelsAsync();
            return hotels.Adapt<IEnumerable<HotelDto>>();
        }
    }
}

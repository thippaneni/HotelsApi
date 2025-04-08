using Hotels.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.CQRS.Hotels.Queries
{
    public record GetAllHotelsQuery()
    : IRequest<IEnumerable<HotelDto>>;
}

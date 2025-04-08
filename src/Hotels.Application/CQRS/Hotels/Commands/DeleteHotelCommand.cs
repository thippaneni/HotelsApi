using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.CQRS.Hotels.Commands
{
    public record DeleteHotelCommand(Guid hotelId)
         : IRequest<bool>;
}

using Hotels.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Interafces
{
    public interface IEventPublisher
    {
        Task PublishAsync(HotelCreatedEvent hotelCreatedEvent, string topicName);
        //Task PublishAsync<T>(T @event, string topicName);
    }
}

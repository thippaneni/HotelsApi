using Azure.Messaging.ServiceBus;
using Hotels.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Azure
{
    public class AzureServicebusEventPublisher(ServiceBusClient client) : IEventPublisher
    {
        private readonly ServiceBusClient _client = client;
        public async Task PublishAsync(HotelCreatedEvent hotelCreatedEvent, string topicName)
        {
            var sender = _client.CreateSender(topicName);
            var message = new ServiceBusMessage(JsonSerializer.Serialize(hotelCreatedEvent))
            {
                ContentType = "application/json"
            };

            await sender.SendMessageAsync(message);
        }
    }
}

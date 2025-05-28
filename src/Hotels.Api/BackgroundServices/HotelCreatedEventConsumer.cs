using Azure.Messaging.ServiceBus;
using Hotels.Domain.DomainEvents;
using System.Text.Json;

namespace Hotels.Api.BackgroundServices
{
    public class HotelCreatedEventConsumer(ServiceBusClient client) : BackgroundService
    {
        private readonly ServiceBusClient _client = client;
        override protected async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // This method will be called when the background service starts.
            // You can implement your logic to consume hotel created events here.

            //while (!stoppingToken.IsCancellationRequested)
            //{

            //}

            var processor = _client.CreateProcessor("hotel-created-topic", "hotel-creted-subscription",
                new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = false
                });

            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;
            // Simulate some work

            await processor.StartProcessingAsync(stoppingToken);
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            var json = args.Message.Body.ToString();
            var hotelCretedEvent = JsonSerializer.Deserialize<HotelCreatedEvent>(json);

            // actual BL goes here
            // Save to Cosmos DB, SQL DB, etc.
            Console.WriteLine($"Received hotel created event for: {hotelCretedEvent.Name}");

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Error: {args.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}

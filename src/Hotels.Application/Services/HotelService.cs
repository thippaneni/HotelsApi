using Hotels.Application.Interafces;
using Hotels.Domain.DomainEvents;
using Hotels.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Hotels.Application.Services
{
    public class HotelService(IHotelRepository hotelRepository, 
        ILogger<HotelService> logger, IEventPublisher publisher) : IHotelService
    {
        private readonly ILogger<HotelService> _logger = logger;
        private readonly IEventPublisher _publisher = publisher;

        public async Task<Hotel> CreateAsync(Hotel hotel)
        {
            _logger.LogInformation("Creating hotel with name: {HotelName}", hotel.Name);
            if (string.IsNullOrEmpty(hotel.Name))
            {
                _logger.LogError("Hotel name is null or empty");
                throw new ArgumentException("Hotel name cannot be null or empty");
            }
            if (hotel.Stars < 1 || hotel.Stars > 5)
            {
                _logger.LogError("Hotel stars must be between 1 and 5");
                throw new ArgumentOutOfRangeException("Stars", "Hotel stars must be between 1 and 5");
            }
            _logger.LogInformation("Adding hotel with name: {HotelName}", hotel.Name);
            
            var createdhotel = await hotelRepository.AddAsync(hotel);

            if (createdhotel != null)
            {
                var hotelCreatedEvent = new HotelCreatedEvent()
                {
                    Address = createdhotel.Address,
                    Description = createdhotel.Description,
                    HotelId = createdhotel.Id,
                    CreatedAt = createdhotel.CreateAt,
                    CreatedBy = createdhotel.CreatedBy ?? "",
                    Name = createdhotel.Name,
                    Stars = createdhotel.Stars
                };
                await _publisher.PublishAsync(hotelCreatedEvent, "hotel-created-topic");
            }
            return createdhotel;
        }

        public async Task<bool> DeleteHotelAsync(Guid id)
        {
            return await hotelRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHOtelsAsync()
        {
            var hashcode = hotelRepository.GetHashCode();
            var hotels = await hotelRepository.GetAllAsync();
            return hotels;
        }

        public async Task<Hotel> GetHotelByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching hotel with ID: {HotelId} in Service", id);
            try
            {
                var hotel = await hotelRepository.GetByIdAsync(id);
                return hotel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hotel not found with ID: {HotelId}", id);
                throw;
            }
        }

        public async Task<Hotel> GetHotelByNameAsync(string name)
        {
            var hotel = await hotelRepository.GetByNameAsync(name);
            return hotel;
        }

        public async Task<Hotel> UdpateHotelAsync(Hotel hotel)
        {
            return await hotelRepository.UdpateAsync(hotel);
        }
    }
}

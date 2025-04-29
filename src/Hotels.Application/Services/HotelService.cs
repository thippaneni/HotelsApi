using Hotels.Application.Interafces;
using Hotels.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Hotels.Application.Services
{
    public class HotelService(IHotelRepository hotelRepository, ILogger<HotelService> logger) : IHotelService
    {
        private readonly ILogger<HotelService> _logger = logger;
        public async Task<Hotel> CreateAsync(Hotel hotel)
        {
            return await hotelRepository.AddAsync(hotel);
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

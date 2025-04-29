using Hotels.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Hotels.Infrastructure.Repository
{
    public class HotelRepository(ApplicationDbContext context, ILogger<HotelRepository> logger) : IHotelRepository
    {
        private readonly ILogger<HotelRepository> _logger = logger;
        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            await context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();
            return hotel;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var hotel = await context.Hotels.FindAsync(id);
            if (hotel == null)
                return false;
            context.Hotels.Remove(hotel);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            var hotels = await context.Hotels.Include(h => h.Reviews).ToListAsync();            
            return hotels;
        }

        public async Task<Hotel> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching hotel with ID: {HotelId}", id);
            try
            {
                var hotel = await context.Hotels.Include(h => h.Reviews)
                .FirstOrDefaultAsync(h => h.Id == id);
                return hotel ?? throw new HotelNotFoundException(id);
            }
            catch (HotelNotFoundException ex)
            {
                _logger.LogError(ex, "Hotel not found with ID: {HotelId}", id);
                throw new HotelNotFoundException(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hotel not found with ID: {HotelId}", id);
                throw new HotelNotFoundException(id);
            }
        }

        public async Task<Hotel> GetByNameAsync(string name)
        {
            return await context.Hotels
                .FirstOrDefaultAsync(h => h.Name == name);
        }

        public async Task<Hotel> UdpateAsync(Hotel hotel)
        {
            var existingHotel = await context.Hotels.FindAsync(hotel.Id);
                        
            if (existingHotel == null)
                return null;

            context.Entry(existingHotel).CurrentValues.SetValues(hotel);
            await context.SaveChangesAsync();
            return existingHotel;
        }
    }
}

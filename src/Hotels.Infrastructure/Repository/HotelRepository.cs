using Hotels.Application.Interafces;
using Hotels.Domain.Models;
using Hotels.Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Repository
{
    public class HotelRepository(InMemoryDbContext context) : IHotelRepository
    {        

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
            var hotels = await context.Hotels.ToListAsync();
            return hotels;
        }

        public Task<Hotel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> UdpateAsync(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}

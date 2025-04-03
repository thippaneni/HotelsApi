using Hotels.Application.Interafces;
using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Services
{
    public class HotelService(IHotelRepository hotelRepository) : IHotelService
    {
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
            var hotel = await hotelRepository.GetByIdAsync(id);
            return hotel;

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

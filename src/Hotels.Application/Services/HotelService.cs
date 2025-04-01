using Hotels.Application.Interafces;
using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository) 
        {
            _hotelRepository = hotelRepository;
        }
        public async Task CreateAsync(Hotel hotel)
        {
            await _hotelRepository.AddAsync(hotel);
        }

        public async Task DeleteHotelAsync(Guid id)
        {
            await _hotelRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHOtelsAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            return hotels;
        }

        public async Task<Hotel> GetHotelByIdAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            return hotel;

        }

        public async Task<Hotel> GetHotelByNameAsync(string name)
        {
            var hotel = await _hotelRepository.GetByNameAsync(name);
            return hotel;
        }

        public async Task UdpateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.UdpateAsync(hotel);
        }
    }
}

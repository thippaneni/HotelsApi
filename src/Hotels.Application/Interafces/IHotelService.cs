using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Interafces
{
    public interface IHotelService
    {
        Task<Hotel> CreateAsync(Hotel hotel);
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<Hotel> GetHotelByNameAsync(string name);
        Task<IEnumerable<Hotel>> GetAllHOtelsAsync();
        Task<Hotel> UdpateHotelAsync(Hotel hotel);
        Task<bool> DeleteHotelAsync(Guid id);
    }
}

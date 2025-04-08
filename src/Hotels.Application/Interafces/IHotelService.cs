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
        // Commands
        Task<Hotel> CreateAsync(Hotel hotel);
        Task<Hotel> UdpateHotelAsync(Hotel hotel);
        Task<bool> DeleteHotelAsync(Guid id);

        // Queries
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<Hotel> GetHotelByNameAsync(string name);
        Task<IEnumerable<Hotel>> GetAllHOtelsAsync();        
    }
}

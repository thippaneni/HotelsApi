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
        Task CreateAsync(Hotel hotel);
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<Hotel> GetHotelByNameAsync(string name);
        Task<IEnumerable<Hotel>> GetAllHOtelsAsync();
        Task UdpateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(Guid id);
    }
}

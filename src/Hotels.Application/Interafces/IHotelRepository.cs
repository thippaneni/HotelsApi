using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Interafces
{
    public interface IHotelRepository
    {
        Task<Hotel> AddAsync(Hotel hotel);
        Task<Hotel> GetByIdAsync(Guid id);
        Task<Hotel> GetByNameAsync(string name);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> UdpateAsync(Hotel hotel);
        Task<bool> DeleteAsync (Guid id);
    }
}

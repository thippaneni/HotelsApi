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
        Task AddAsync(Hotel hotel);
        Task<Hotel> GetByIdAsync(Guid id);
        Task<Hotel> GetByNameAsync(string name);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task UdpateAsync(Hotel hotel);
        Task DeleteAsync (Guid id);
    }
}

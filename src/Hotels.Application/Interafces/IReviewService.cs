using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Interafces
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviewsByHotelIdAsync(Guid hotelId);
        Task<Review?> GetReviewByIdAsync(Guid id);
        Task<Review?> CreateReviewAsync(Review review);
        Task<Review?> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(Guid id);
    }
}

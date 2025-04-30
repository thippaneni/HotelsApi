using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Interafces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsByHotelIdAsync(Guid hotelId);
        Task<Review?> GetReviewByIdAsync(Guid id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review?> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(Guid id);
        Task<List<Review>> GetReviewsByHotelIdV2Async(Guid hotelId);
    }
}

using Hotels.Application.Interafces;
using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Services
{
    public class ReviewService(IReviewRepository _reviewRepository) : IReviewService
    {
        public async Task<Review?> CreateReviewAsync(Review review)
        {
           return await _reviewRepository.AddReviewAsync(review);
        }

        public async Task<bool> DeleteReviewAsync(Guid id)
        {
            return await _reviewRepository.DeleteReviewAsync(id);
        }

        public async Task<Review?> GetReviewByIdAsync(Guid id)
        {
            return await _reviewRepository.GetReviewByIdAsync(id);
        }

        public async Task<List<Review>> GetReviewsByHotelIdAsync(Guid hotelId)
        {
            return await _reviewRepository.GetReviewsByHotelIdAsync(hotelId);
        }

        public async Task<Review?> UpdateReviewAsync(Review review)
        {
            return await _reviewRepository.UpdateReviewAsync(review);
        }
    }
}

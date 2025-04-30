namespace Hotels.Infrastructure.Repository
{
    public class ReviewRepository(ApplicationDbContext _context) : IReviewRepository
    {
        public async Task<Review> AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteReviewAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Review?> GetReviewByIdAsync(Guid id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<List<Review>> GetReviewsByHotelIdAsync(Guid hotelId)
        {
            IEnumerable<Review> reviews = await _context.Reviews
                .Where(r => r.HotelId == hotelId && r.Rating > 3)
                .ToListAsync();

            //var reviewList = reviews.Where(r => r.Rating > 3);

            return reviews.ToList();
        }

        public async Task<List<Review>> GetReviewsByHotelIdV2Async(Guid hotelId)
        {
            IQueryable<Review> reviews = _context.Reviews
                .Where(r => r.HotelId == hotelId && r.Rating > 3);
            
            //var reviewList = reviews.Where(r => r.Rating > 3);

            return await reviews.ToListAsync();
        }

        public async Task<Review?> UpdateReviewAsync(Review review)
        {
            var existingReview = await _context.Reviews.FindAsync(review.Id);
            if (existingReview == null)
                return null;

            _context.Entry(existingReview).CurrentValues.SetValues(review);
            await _context.SaveChangesAsync();
            return existingReview;
        }
    }
}

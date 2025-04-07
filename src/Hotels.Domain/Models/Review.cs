using Hotels.Domain.Entity;

namespace Hotels.Domain.Models
{
    public class Review : BaseEntirty
    {        
        public string ReviewerName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }     
        public Guid HotelId { get; set; }
    }
}

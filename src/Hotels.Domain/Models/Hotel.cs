using Hotels.Domain.Entity;

namespace Hotels.Domain.Models
{
    public class Hotel : BaseEntirty
    {        
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Stars { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Review> Reviews { get; set; } = [];

    }
}

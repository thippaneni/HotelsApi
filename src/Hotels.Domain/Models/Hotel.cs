using Hotels.Domain.Entity;

namespace Hotels.Domain.Models
{
    public class Hotel : BaseEntirty
    {        
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Review> Reviews { get; set; }
        
    }
}

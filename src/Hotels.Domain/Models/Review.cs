using Hotels.Domain.Entity;

namespace Hotels.Domain.Models
{
    public class Review : BaseEntirty
    {
        public string Comment { get; set; }        
        public string ReviewerName { get; set; }

        public Hotel Hotel { get; set; }
    }
}

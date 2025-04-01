namespace Hotels.Domain.Entity
{
    public abstract class BaseEntirty
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? LastModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUdpatedBy { get; set; }
    }
            
}

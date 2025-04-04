namespace Hotels.Infrastructure.Persistent
{    
    public class InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : DbContext(options)
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}

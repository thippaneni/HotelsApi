using Hotels.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Persistent
{    
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntirty).IsAssignableFrom(entityType.ClrType))
                {
                    // Configure CreatedAt with a default SQL value (using GETDATE() for SQL Server)
                    modelBuilder.Entity(entityType.ClrType)
                                .Property<DateTime>("CreateAt")
                                .IsRequired()
                                .HasDefaultValueSql("GETDATE()");

                    // Configure CreatedBy with a max length, required
                    modelBuilder.Entity(entityType.ClrType)
                                .Property<string>("CreatedBy")
                                .IsRequired()
                                .HasMaxLength(100);

                    // Optionally configure UpdatedAt and UpdatedBy
                    modelBuilder.Entity(entityType.ClrType)
                                .Property<DateTime?>("LastModified");

                    modelBuilder.Entity(entityType.ClrType)
                                .Property<string>("LastUdpatedBy")
                                .HasMaxLength(100);
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}

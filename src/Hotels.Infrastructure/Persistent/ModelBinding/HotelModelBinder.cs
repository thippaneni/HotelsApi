using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Persistent.ModelBinding
{
    public class HotelModelBinder : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> entity)
        {
            entity.HasKey(h => h.Id);
            entity.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(h => h.Address);
            entity.Property(h => h.Stars);
            entity.Property(h => h.Description)
                .IsRequired()
                .HasMaxLength(500);

            // Configure one-to-many relationship using a shadow property "HotelId" for Review.
            entity.HasMany(h => h.Reviews)
                .WithOne()
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

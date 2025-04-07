using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Persistent.ModelBinding
{
    public class ReviewModelBinder : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.ReviewerName)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.Property(r => r.Comment)
                  .HasMaxLength(1000);
            entity.Property(r => r.Rating)
                  .IsRequired();
            entity.Property(r => r.HotelId)
                  .IsRequired();
        }
    }
}

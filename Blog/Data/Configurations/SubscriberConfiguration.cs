using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasIndex(s => s.Email).IsUnique();
            builder.Property(s => s.Email).IsRequired().HasMaxLength(200);

            builder.Property(s => s.Status).HasConversion<string>().IsRequired().HasMaxLength(50);
        }
    }
}

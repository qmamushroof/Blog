using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(t => t.Slug).IsUnique();
            builder.Property(t => t.Slug).IsRequired().HasMaxLength(100);

            builder.HasIndex(t => t.Name).IsUnique();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

            builder.Property(t => t.Description).HasMaxLength(500);
        }
    }
}

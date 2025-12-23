using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.Slug).IsUnique();
            builder.Property(c => c.Slug).IsRequired().HasMaxLength(100);

            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Description).HasMaxLength(500);
        }
    }
}

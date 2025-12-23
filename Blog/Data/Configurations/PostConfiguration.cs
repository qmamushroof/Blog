using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(p => p.Slug).IsUnique();
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(300);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(300);

            builder.Property(p => p.Content).IsRequired();

            builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(50);
            builder.Property(p => p.Priority).HasConversion<string>().HasMaxLength(50);

            builder.Property(p => p.HeaderImageUrl).HasMaxLength(500);
            builder.Property(p => p.AuthorId).HasMaxLength(100);

            builder.HasOne(p => p.Category).WithMany(c => c.Posts)
            .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}

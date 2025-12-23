using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public class PostConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(p => p.Slug).IsUnique();
                entity.Property(p => p.Slug).IsRequired().HasMaxLength(300);

                entity.Property(p => p.Title).IsRequired().HasMaxLength(300);

                entity.Property(p => p.Content).IsRequired();

                entity.Property(p => p.Status).HasConversion<string>().HasMaxLength(50);
                entity.Property(p => p.Priority).HasConversion<string>().HasMaxLength(50);

                entity.Property(p => p.HeaderImageUrl).HasMaxLength(500);
                entity.Property(p => p.AuthorId).HasMaxLength(100);

                entity.HasOne(p => p.Category).WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

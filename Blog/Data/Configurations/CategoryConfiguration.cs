using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public class CategoryConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Slug).IsUnique();
                entity.Property(c => c.Slug).IsRequired().HasMaxLength(100);

                entity.HasIndex(c => c.Name).IsUnique();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);

                entity.Property(c => c.Description).IsRequired().HasMaxLength(500);
            });
        }
    }
}

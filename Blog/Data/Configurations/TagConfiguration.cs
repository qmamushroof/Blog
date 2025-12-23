using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public class TagConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(t => t.Slug).IsUnique();
                entity.Property(t => t.Slug).IsRequired().HasMaxLength(100);

                entity.HasIndex(t => t.Name).IsUnique();
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);

                entity.Property(t => t.Description).HasMaxLength(500);
            });
        }
    }
}

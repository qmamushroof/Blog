using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public class SubscriberConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.HasIndex(s => s.Email).IsUnique();
                entity.Property(s => s.Email).IsRequired().HasMaxLength(200);

                entity.Property(s => s.Status).HasConversion<string>().IsRequired().HasMaxLength(50);
            });
        }
    }
}

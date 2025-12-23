using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public class PostTagConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(pt => new { pt.PostId, pt.TagId });

                entity.HasOne(pt => pt.Post).WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pt => pt.Tag).WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

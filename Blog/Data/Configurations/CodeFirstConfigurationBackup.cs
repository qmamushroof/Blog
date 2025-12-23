using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public static class CodeFirstConfigurationBackup
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(p => p.Slug).IsUnique();
                entity.Property(p => p.Slug).IsRequired().HasMaxLength(300);

                entity.Property(p => p.Title).IsRequired().HasMaxLength(300);

                entity.Property(p => p.Content).IsRequired();

                entity.Property(p => p.Status).HasConversion<string>();
                entity.Property(p => p.Priority).HasConversion<string>();

                entity.HasOne(p => p.Category).WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Slug).IsUnique();
                entity.Property(c => c.Slug).IsRequired().HasMaxLength(100);

                entity.HasIndex(c => c.Name).IsUnique();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(t => t.Slug).IsUnique();
                entity.Property(t => t.Slug).IsRequired().HasMaxLength(100);

                entity.HasIndex(t => t.Name).IsUnique();
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(pt => new { pt.PostId, pt.TagId });

                entity.HasOne(pt => pt.Post).WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pt => pt.Tag).WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.HasIndex(s => s.Email).IsUnique();
                entity.Property(s => s.Email).IsRequired().HasMaxLength(200);

                entity.Property(s => s.Status).HasConversion<string>();
            });

            modelBuilder.Entity<ShareTrack>(entity =>
            {
                entity.HasIndex(st => st.PostId);

                entity.Property(st => st.Platform).HasMaxLength(100);

                entity.HasOne(st => st.Post).WithMany(p => p.ShareTracks)
                .HasForeignKey(st => st.PostId).OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}

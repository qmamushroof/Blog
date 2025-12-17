using Blog.Data.Seeding;
using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<ShareTrack> ShareTracks { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(p => p.Slug).IsUnique();
                entity.Property(p => p.Slug).IsRequired().HasMaxLength(300);

                entity.Property(p => p.Title).IsRequired().HasMaxLength(300);

                entity.Property(p => p.Content).IsRequired();

                entity.Property(p => p.AuthorId).IsRequired();

                entity.HasOne(p => p.Category).WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasIndex(c => c.Slug).IsUnique();
                entity.Property(c => c.Slug).IsRequired().HasMaxLength(100);

                entity.HasIndex(c => c.Name).IsUnique();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(t => t.Id);

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
                entity.HasKey(s => s.Id);

                entity.HasIndex(s => s.Email).IsUnique();

                entity.Property(s => s.Email).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<ShareTrack>(entity =>
            {
                entity.HasKey(st => st.Id);

                entity.HasIndex(st => st.PostId);

                entity.Property(st => st.Platform).HasMaxLength(100);

                entity.HasOne(st => st.Post).WithMany(p => p.ShareTracks)
                .HasForeignKey(st => st.PostId).OnDelete(DeleteBehavior.SetNull);
            });

            BlogSeeder.Seed(modelBuilder);
        }
    }
}

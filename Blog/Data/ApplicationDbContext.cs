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

                entity.Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
                
                entity.Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(p => p.Category).WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Category>();

            modelBuilder.Entity<Tag>();

            modelBuilder.Entity<PostTag>();

            modelBuilder.Entity<Subscriber>();

            modelBuilder.Entity<ShareTrack>();
        }
    }
}

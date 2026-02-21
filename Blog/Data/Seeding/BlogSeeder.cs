using Blog.Models.Entities;
using Blog.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Seeding
{
    public static class BlogSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Student Visas", Slug = "student-visas", Description = "All about student visa processes", PostCount = 1 },
                new Category { Id = 2, Name = "University Applications", Slug = "university-applications" },
                new Category { Id = 3, Name = "Scholarships", Slug = "scholarships" }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Australia", Slug = "australia" },
                new Tag { Id = 2, Name = "UK", Slug = "uk" },
                new Tag { Id = 3, Name = "Canada", Slug = "canada" },
                new Tag { Id = 4, Name = "Tips", Slug = "tips" },
                new Tag { Id = 5, Name = "News", Slug = "news" }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Welcome to My Blog",
                    Slug = "welcome-to-my-blog",
                    Content = "<p>This is my first blog post...</p>",
                    Status = PostStatus.Published,
                    Priority = PostPriority.Pinned,
                    PublishedAt = new DateTime(2025, 12, 17),
                    CreatedAt = new DateTime(2025, 12, 17),
                    UpdatedAt = new DateTime(2025, 12, 17),
                    AuthorId = "admin-temp-001",
                    CategoryId = 1,
                    HeaderImageUrl = null,
                    ShareCount = 15
                }
            );

            modelBuilder.Entity<PostTag>().HasData(
                new PostTag { PostId = 1, TagId = 1 },
                new PostTag { PostId = 1, TagId = 4 },
                new PostTag { PostId = 1, TagId = 5 }
            );
        }
    }
}
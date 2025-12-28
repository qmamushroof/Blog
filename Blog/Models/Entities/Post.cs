using Blog.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public PostStatus Status { get; set; } = PostStatus.Draft;
        public PostPriority Priority { get; set; } = PostPriority.Normal;

        public DateTime? PublishedAt { get; set; }
        public DateTime? Deadline { get; set; }

        public string? HeaderImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        public string? AuthorId { get; set; } = string.Empty;
        //public ApplicationUser? Author { get; set; }

        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
        public ICollection<ShareTrack> ShareTracks { get; set; } = new List<ShareTrack>();

        public int ShareCount { get; set; } = 0;
    }
}

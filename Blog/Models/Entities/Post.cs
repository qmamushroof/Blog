using Blog.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class Post : Base
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }

        public Status Status { get; set; } = Status.Draft;
        public Priority Priority { get; set; } = Priority.Normal;

        public DateTime PublishedAt { get; set; }
        public DateTime Deadline { get; set; }

        public string? HeaderImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //[ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        //public Category? Category { get; set; }
        //[ForeignKey(nameof(ApplicationUser))]
        public string? AuthorId { get; set; }
        //public ApplicationUser? Author { get; set; }

        //public ICollection<PostTag>? PostTags { get; set; } = new List<PostTag>();
        //public ICollection<ShareTrack>? ShareTracks { get; set; } = new List<ShareTrack>();

        public int ShareCount { get; set; } = 0;
    }
}

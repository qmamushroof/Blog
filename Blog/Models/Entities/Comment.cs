using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Logic.Model
{
    public class Comment
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; } = new();
        public long? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public long? AuthorId { get; set; }
        //public User? Author { get; set; }
        public string Content { get; set; } = string.Empty;
        public CommentStatus Status { get; set; } = CommentStatus.Approved;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? SoftDeletedAt { get; set; }
        public string? GuestName { get; set; } // for non-logged in users
        public string? GuestEmail { get; set; } // for non-logged in users
        public ICollection<Comment> Replies { get; set; } = new HashSet<Comment>();
    }
}

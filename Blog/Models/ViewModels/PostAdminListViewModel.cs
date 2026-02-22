using Blog.Models.Entities;
using Blog.Models.Enums;
using System.ComponentModel;

namespace Blog.Models.ViewModels
{
    public class PostAdminListViewModel : PostListViewModel
    {
        public PostStatus Status { get; set; }
        public PostPriority Priority { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? SoftDeletedAt { get; set; }
    }
}